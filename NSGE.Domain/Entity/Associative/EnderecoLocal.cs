using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class EnderecoLocal : EntityBase
    {
        public string EnderecoId { get; set; }
        public string LocalId { get; set; }

        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }

        [ForeignKey("LocalId")]
        public virtual Local Local { get; set; }

        public EnderecoLocal() { }

        public EnderecoLocal(string enderecoId, string localId)
        {
            EnderecoId = enderecoId;
            LocalId = localId;
            Endereco = new Endereco();
        }
    }
}