using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;

namespace NSGE.Domain.Entity.Associative
{
    public class PessoaQualificacao : EntityBase
    {
        public string PessoaId { get; set; }
        public string? QualificacaoId { get; set; }

        public Pessoa Pessoa { get; set; }
        public Qualificacao Qualificacao { get; set; }
    }
}