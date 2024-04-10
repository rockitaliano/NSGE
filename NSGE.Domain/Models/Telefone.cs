using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models
{
    public class Telefone : EntityBase
    {
        [StringLength(5, ErrorMessageResourceName = "MaxLength")]
        public string DDD { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessageResourceName = "Required")]
        [StringLength(30, ErrorMessageResourceName = "MaxLength")]
        public string Numero { get; set; }

        public bool Principal { get; set; }

        public string IdDoContato { get; set; }

        [ForeignKey("IdDoContato")]
        public Contato Contato { get; set; }

        public bool isValido()
        {
            return !string.IsNullOrEmpty(this.Numero) && this.Numero.Length <= 30;
        }

        public object ConvertToJson()
        {
            return new
            {
                Id = this.Id,
                DDD = this.DDD,
                Numero = this.Numero,
                Principal = this.Principal,
                IdDoContato = this.IdDoContato
            };
        }
    }
}