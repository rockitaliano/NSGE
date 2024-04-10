using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Models
{
    public class AgendaTecnica : EntityBase
    {
        public string EventoId { get; set; }
        public DateTime Data { get; set; }
        public string BgColor { get; set; }
        public string FontColor { get; set; }

        public bool Exibir { get; set; }

        [ForeignKey("EventoId")]
        public virtual Evento Evento { get; set; }

        public virtual IList<TecnicoDia> Tecnicos { get; set; }

        public AgendaTecnica()
        {
            Exibir = true;
            Tecnicos = new List<TecnicoDia>();
        }
    }
}