using NSGE.CrossCutting.BaseEntity;

namespace NSGE.Domain.Entity.Operacional
{
    public class EstoqueHistorico : EntityBase
    {
        public string ProdutoNome { get; set; }
        public int CodigoInterno { get; set; }
        public string NumeroDaOs { get; set; }
        public string EventoNome { get; set; }
        public string ClienteNome { get; set; }
        public string StatusDescricao { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
    }
}