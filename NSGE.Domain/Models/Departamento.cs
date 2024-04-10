using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models
{
    public class Departamento : EntityBase
    {
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "StringLength")]
        public string Descricao { get; set; }
    }
}