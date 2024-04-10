using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Operacional;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class MotoristaOrdemServico : EntityBase
    {
        public string? IdOrdemServico { get; set; }
        public string? IdPessoa { get; set; }

        [ForeignKey("IdOrdemServico")]
        public OrdemServico? OrdemServico { get; set; }

        [ForeignKey("IdPessoa")]
        public Pessoa? Motorista { get; set; }
    }
}