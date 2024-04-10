using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models
{
    public class Qualificacao : EntityBase
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Nome { get; set; }
    }
}