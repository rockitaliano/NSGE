using Microsoft.AspNetCore.Mvc;

namespace NSGE.Domain.Entity.CheckList
{
    public class MontarConteudoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ItemChecklist model)
        {
            return View(model);
        }
    }
}