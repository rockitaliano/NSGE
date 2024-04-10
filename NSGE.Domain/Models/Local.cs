using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Messages;
using NSGE.Domain.Entity.Associative;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models
{
    public class Local : EntityBase
    {
        [Display(Name = "Descrição")]  
        public string Descricao { get; set; }

        public virtual IList<EnderecoLocal> Enderecos { get; set; }
        public EnderecoLocal? EnderecoLocal { get; set; }
        
        public Local()
        {
            this.Enderecos = new List<EnderecoLocal>();  
            this.EnderecoLocal = new EnderecoLocal();
        }
    }
}