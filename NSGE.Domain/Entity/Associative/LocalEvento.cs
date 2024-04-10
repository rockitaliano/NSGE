using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class LocalEvento : EntityBase
    {
        public string EventoId { get; set; }
        public string LocalId { get; set; }
        public string EnderecoId { get; set; }

        [ForeignKey("LocalId")]
        public virtual Local Local { get; set; }

        public LocalEvento()
        { }

        public LocalEvento(string localId, string enderecoId, string eventoId)
        {
            LocalId = localId;
            EnderecoId = enderecoId;
            EventoId = eventoId;
        }
    }
}