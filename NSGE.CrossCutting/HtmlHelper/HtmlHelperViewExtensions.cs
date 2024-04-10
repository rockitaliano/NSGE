using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace NSGE.CrossCutting.HtmlHelper
{
    public static class HtmlHelperViewExtensions
    {
        public static IHtmlContent Action(this IHtmlHelper helper, string action, object parameters = null)
        {
            var controller = (string)helper.ViewContext.RouteData.Values["controller"];

            return Action(helper, action, controller, parameters);
        }

        public static IHtmlContent Action(this IHtmlHelper helper, string action, string controller, object parameters = null)
        {
            var area = (string)helper.ViewContext.RouteData.Values["area"];

            return Action(helper, action, controller, area, parameters);
        }

        public static IHtmlContent ActionTeste(this IHtmlHelper helper, string action, string controller, object parameters = null)
        {
            var task = RenderActionAsync(helper, action, controller, null, parameters);
            return task.Result;
        }

        public static IHtmlContent Action(this IHtmlHelper helper, string action, string controller, string area, object parameters = null)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            if (controller == null)
                throw new ArgumentNullException("controller");


            var task = RenderActionAsync(helper, action, controller, area, parameters);

            return task.Result;
        }

        private static async Task<IHtmlContent> RenderActionAsync(this IHtmlHelper helper, string action, string controller, string area, object parameters = null)
        {
            // fetching required services for invocation
            var serviceProvider = helper.ViewContext.HttpContext.RequestServices;
            var actionContextAccessor = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>();
            var httpContextAccessor = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();
            var actionSelector = serviceProvider.GetRequiredService<IActionSelector>();

            // creating new action invocation context
            var routeData = new RouteData();
            foreach (var router in helper.ViewContext.RouteData.Routers)
            {
                routeData.PushState(router, null, null);
            }
            routeData.PushState(null, new RouteValueDictionary(new { controller = controller, action = action, area = area }), null);
            routeData.PushState(null, new RouteValueDictionary(parameters ?? new { }), null);

            //get the actiondescriptor
            RouteContext routeContext = new RouteContext(helper.ViewContext.HttpContext) { RouteData = routeData };
            var candidates = actionSelector.SelectCandidates(routeContext);
            var actionDescriptor = actionSelector.SelectBestCandidate(routeContext, candidates);

            var originalActionContext = actionContextAccessor.ActionContext;
            var originalhttpContext = httpContextAccessor.HttpContext;
            try
            {
                var newHttpContext = serviceProvider.GetRequiredService<IHttpContextFactory>().Create(helper.ViewContext.HttpContext.Features);
                if (newHttpContext.Items.ContainsKey(typeof(IUrlHelper)))
                {
                    newHttpContext.Items.Remove(typeof(IUrlHelper));
                }
                newHttpContext.Response.Body = new MemoryStream();
                var actionContext = new ActionContext(newHttpContext, routeData, actionDescriptor);
                actionContextAccessor.ActionContext = actionContext;
                var invoker = serviceProvider.GetRequiredService<IActionInvokerFactory>().CreateInvoker(actionContext);
                await invoker.InvokeAsync();
                newHttpContext.Response.Body.Position = 0;
                using (var reader = new StreamReader(newHttpContext.Response.Body))
                {
                    return new HtmlString(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                return new HtmlString(ex.Message);
            }
            finally
            {
                actionContextAccessor.ActionContext = originalActionContext;
                httpContextAccessor.HttpContext = originalhttpContext;
                if (helper.ViewContext.HttpContext.Items.ContainsKey(typeof(IUrlHelper)))
                {
                    helper.ViewContext.HttpContext.Items.Remove(typeof(IUrlHelper));
                }
            }
        }
        //public static IHtmlContent Action(this IHtmlHelper helper, string action, string controller, object parameters = null)
        //{
        //    var controller = (string)helper.ViewContext.RouteData.Values["controller"];

        //    return Action(helper, action, controller, parameters);
        //    //var task = RenderActionAsync(helper, action, controller, parameters);
        //    //return task.Result;
        //}

        //private static async Task<IHtmlContent> RenderActionAsync(IHtmlHelper helper, string action, string controller, object parameters = null)
        //{
        //    var serviceProvider = helper.ViewContext.HttpContext.RequestServices;
        //    var actionContextAccessor = serviceProvider.GetRequiredService<IActionContextAccessor>();
        //    var actionSelector = serviceProvider.GetRequiredService<IActionSelector>();

        //    var routeData = new RouteData();
        //    routeData.Values["controller"] = controller;
        //    routeData.Values["action"] = action;

        //    var actionDescriptor = actionSelector.SelectCandidates(new RouteContext(helper.ViewContext.HttpContext)).First(i => i.RouteValues["Controller"] == controller && i.RouteValues["Action"] == action);
        //    var actionContext = new ActionContext(helper.ViewContext.HttpContext, routeData, actionDescriptor);

        //    var invokerFactory = serviceProvider.GetRequiredService<IActionInvokerFactory>();
        //    var invoker = invokerFactory.CreateInvoker(actionContext);

        //    string content = null;

        //    await invoker.InvokeAsync().ContinueWith(task =>
        //    {
        //        if (task.IsFaulted)
        //        {
        //            content = task.Exception.Message;
        //        }
        //        else if (task.IsCompletedSuccessfully)
        //        {
        //            content = new StreamReader(actionContext.HttpContext.Response.Body).ReadToEnd();
        //        }
        //    });

        //    return new HtmlString(content);
        //}
    }
}