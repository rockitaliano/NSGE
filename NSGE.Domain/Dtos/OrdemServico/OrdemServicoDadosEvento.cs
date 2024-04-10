using NSGE.Domain.Models;

namespace NSGE.Domain.Dtos
{
    public class OrdemServicoDadosEvento
    {
        public OrdemServicoDadosEvento()
        {
            this.ArquivosProposta = new List<Arquivo>();
        }

        public string IdEvento { get; set; }
        public string NumeroDaOS { get; set; }
        public string EventoDescricao { get; set; }
        public bool ExisteChecklist { get; set; }
        public string UrlChecklist { get; set; }

        public Pessoa CoordenadorTecnico { get; set; }
        public IList<Arquivo> ArquivosProposta { get; set; }

        public string IdEndereco { get; set; }
        public string IdLocal { get; set; }
        public Local Local { get; set; }

        public IList<Contato> Contatos { get; set; }
    }
}