using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Interface;
using NSGE.Domain.Entity.Operacional;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class ContatoOrdemServico : EntityBase, IContatoRelacionamento
    {
        public string? ContatoId { get; set; }

        [ForeignKey("ContatoId")]
        public virtual Contato? Contato { get; set; }

        public string? OrdemServicoId { get; set; }

        [ForeignKey("OrdemServicoId")]
        public OrdemServico? OrdemServico { get; set; }
    }
}