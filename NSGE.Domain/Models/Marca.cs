using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Messages;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models
{
    public class Marca : EntityBase
    {
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "StringLength")]
        public string? Descricao { get; set; }
    }
}