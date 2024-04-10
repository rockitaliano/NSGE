namespace NSGE.Domain.Models
{
    public class AlmoxarifadoIndexViewModel
    {
        public string PessoaId { get; set; }
        public string? PessoaNome { get; set; }
        public string? Funcao { get; set; }
        public double Total { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

        public string TotalFormatado
        {
            get
            {
                return Total.ToString("N2");
            }
        }
    }
}