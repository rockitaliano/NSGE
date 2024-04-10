using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Propostas;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class EventoProposta : EntityBase
    {
        // Quando for buscar, buscar por este Id
        // Altera por ele
        // Exclui por ele
        // Adicionar vc passa o objeto completo

        public string? PropostaId { get; set; }
        public string? EventoId { get; set; }

        [ForeignKey("EventoId")]
        public virtual Evento? Eventos { get; set; }

        [ForeignKey("PropostaId")]
        public virtual Proposta? Propostas { get; set; }
    }
}