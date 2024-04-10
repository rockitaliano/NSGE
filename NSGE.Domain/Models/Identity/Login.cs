using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models.Identity
{
    public class Login : EntityBase
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "MaxLength")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(32, ErrorMessage = "MaxLength")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool Lembrarme { get; set; }
    }
}