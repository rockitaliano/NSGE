using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Messages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Models
{
    [Table("Source")]
    public class Source : EntityBase
    {
        [Display(Name = "Texto")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Text { get; set; }

        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Tela { get; set; }

        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Campo { get; set; }
    }
}