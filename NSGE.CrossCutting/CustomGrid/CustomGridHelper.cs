using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NSGE.CrossCutting.CustomGrid
{
    public static class CustomGridHelper
    {
        public static IHtmlContent CustomGrid<T>(this IHtmlHelper helper, CustomGridDataSource<T> dataSource, string[] columns, bool sortable = true, bool groupable = true, bool showLoading = true, IList<CustomGridLink> links = null, bool showPagination = true) where T : class
        {
            // Lógica da geração do conteúdo HTML do grid aqui

            // Você deve retornar um objeto IHtmlContent
            // Exemplo:
            // var content = new HtmlString("<div>Seu Conteúdo HTML</div>");
            // return content;
            return new HtmlString("Seu conteúdo HTML aqui");
        }

        public static IHtmlContent Paginador(this IHtmlHelper helper, int totalCount, int totalPorPagina, int paginaAtual, bool usarAjax = true)
        {
            // Lógica da geração do conteúdo HTML do paginador aqui

            // Você deve retornar um objeto IHtmlContent
            // Exemplo:
            // var content = new HtmlString("<div>Seu Conteúdo HTML</div>");
            // return content;
            return new HtmlString("Seu conteúdo HTML do paginador aqui");
        }
    }
}