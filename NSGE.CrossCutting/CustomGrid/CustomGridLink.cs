namespace NSGE.CrossCutting.CustomGrid
{
    public class CustomGridLink
    {
        public CustomGridLink()
        {
            new CustomGridLink();
        }

        public CustomGridLink(string url, string parametro, string icone, string tooltip, string classe = null)
        {
            Url = url;
            Parametro = parametro;
            Icone = icone;
            Tooltip = tooltip;
            Classe = classe;
        }

        public string Url { get; set; }
        public string Classe { get; set; }
        public string Icone { get; set; }
        public string Tooltip { get; set; }
        public string Parametro { get; set; }
    }
}