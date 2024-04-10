using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class EventoVeiculo : EntityBase
    {
        public string? EventoId { get; set; }
        public string? VeiculoId { get; set; }

        [ForeignKey("EventoId")]
        public virtual Evento? Evento { get; set; }

        [ForeignKey("VeiculoId")]
        public virtual Models.Veiculo? Veiculo { get; set; }
    }
}