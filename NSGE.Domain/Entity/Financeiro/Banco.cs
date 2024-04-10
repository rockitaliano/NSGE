using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Messages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Financeiro
{
    public class Banco : EntityBase
    {
        [Display(Name = "Descrição")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Descricao { get; set; }

        public virtual ICollection<ContaCorrente> Contas { get; set; }

        #region NotMapped

        [NotMapped, Display(Name = "Código")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        [MinLength(3, ErrorMessage = "Informe pelo menos 3 números.")]
        public string Codigo
        {
            get
            {
                var codigo = this.Id;

                //if (codigo.Length > 3)
                //    codigo = codigo.Substring(0, 3);

                return codigo;
            }
            set
            {
                this.Id = value;
            }
        }

        [NotMapped]
        public string OldId { get; set; }

        [NotMapped]
        public bool idMudou
        {
            get
            {
                return this.Id != this.OldId;
            }
        }

        #endregion NotMapped
    }
}