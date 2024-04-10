using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class EventoEquipe : EntityBase
    {
        public string? EventoId { get; set; }
        public string? PessoaId { get; set; }

        [ForeignKey("EventoId")]
        public virtual Evento? Evento { get; set; }

        [ForeignKey("PessoaId")]
        public virtual Pessoa? Pessoa { get; set; }
    }
}