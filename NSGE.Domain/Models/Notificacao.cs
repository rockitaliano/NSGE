using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.CrosCutting.Messages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models
{
    public class Notificacao : EntityBase
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Required")]
        //[StringLength(30, ErrorMessage = "StringLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "EmailAddress")]
        //[StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Email { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Required")]
        public string Tipo { get; set; }

        /// <summary>
        /// Usada na GRID
        /// </summary>
        [NotMapped]
        [Display(Name = "Tipo da Notificação")]
        public string TipoText
        {
            get
            {
                return Tipo.GetEnum<TipoNotificacaoEnum>().GetEnumText();
            }
        }
    }
}
