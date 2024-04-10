using NSGE.CrossCutting.BaseEntity;

namespace NSGE.Domain.Entity.Agenda
{
    public class DiariaTecnicaFiltro : EntityBase
    {
        public string? Tecnico { get; set; }
        public int? Tipo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public decimal ValorDiaria { get; set; }
        public decimal ValorAlimentacao { get; set; }

    }
}