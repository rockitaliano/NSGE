using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Interface;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class ContatoEvento : EntityBase, IContatoRelacionamento
    {
        public string ContatoId { get; set; }

        [ForeignKey("ContatoId")]
        public  Contato? Contato { get; set; }

        public string EventoId { get; set; }

        [ForeignKey("EventoId")]
        public  Evento? Evento { get; set; }

        [NotMapped]
        public bool Vinculado { get; set; }
    }
}