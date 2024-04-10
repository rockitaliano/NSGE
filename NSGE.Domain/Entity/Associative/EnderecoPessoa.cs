using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class EnderecoPessoa : EntityBase
    {
        public string EnderecoId { get; set; }
        public string PessoaId { get; set; }

        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }

        [ForeignKey("PessoaId")]
        public Pessoa Pessoa { get; set; }

        public EnderecoPessoa()
        {
        }

        public EnderecoPessoa(string enderecoId, string pessoaId)
        {
            EnderecoId = enderecoId;
            PessoaId = pessoaId;
        }
    }
}