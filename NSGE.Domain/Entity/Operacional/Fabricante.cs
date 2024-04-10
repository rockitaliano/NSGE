using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Entity.Operacional
{
    public class Fabricante : EntityBase
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceName = "StringLength")]
        public string? Nome { get; set; }
    }
}