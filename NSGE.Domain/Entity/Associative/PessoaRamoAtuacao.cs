using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;

namespace NSGE.Domain.Entity.Associative
{
    public class PessoaRamoAtuacao : EntityBase
    {
        public string PessoaId { get; set; }
        public string RamoAtuacaoId { get; set; }

        public Pessoa Pessoa { get; set; }
        public RamoAtuacao RamoAtuacao { get; set; }
    }
}