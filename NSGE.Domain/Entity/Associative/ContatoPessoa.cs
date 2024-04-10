using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class ContatoPessoa : EntityBase
    {
        public string ContatoId { get; set; }
        public string PessoaId { get; set; }

        [ForeignKey("ContatoId")]
        public Contato Contato { get; set; }

        [ForeignKey("PessoaId")]
        public Pessoa Pessoa { get; set; }

        public dynamic ConvertJson()
        {
            var nomeDisplay = string.IsNullOrEmpty(this.Pessoa.NomeFantasia) ? this.Pessoa.Nome : this.Pessoa.NomeFantasia;
            var display = string.Format("{0} | {1}", nomeDisplay.ToUpper(), this.Contato.Nome);

            //if (this.Pessoa.Nome.ToLower() == this.Contato.Nome.ToLower())
            //    display = this.Contato.Nome;

            dynamic json = this.Contato.ConvertToJson();

            json.DisplaySearch = display;

            return json;
        }
    }
}