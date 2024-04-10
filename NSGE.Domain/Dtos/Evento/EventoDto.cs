using NSGE.CrossCutting.BaseEntity;

namespace NSGE.Domain.Dtos.Evento
{
    public class EventoDto : EntityBase
    {
        public string NumeroDaOS { get; set; }
        public string Cliente { get; set; }
        public string Evento { get; set; }
        public string RepresentanteComercialNome { get; set; }
        public string CoordenadorTecnicoNome { get; set; }
        public DateTime DataDaMontagem { get; set; }
        public DateTime InicioDoEvento { get; set; }
        public DateTime FimDoEvento { get; set; }
        public bool Aprovado { get; set; }
    }
}