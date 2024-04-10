using Microsoft.AspNetCore.Components.Forms;
using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.CrosCutting.Messages;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NSGE.Domain.Models
{
    public class Status : EntityBase
    {
        [Display(Name = "Descrição")]
        //[Required(ErrorMessageResourceType = typeof(DynamicAttribute), ErrorMessageResourceName = "Required")]
        //[StringLength(30, ErrorMessageResourceName = "StringLength")]
        public string? Descricao { get; set; }

        [Display(Name = "Tipo de Cadastro")]
        //[Required(ErrorMessageResourceType = typeof(DynamicAttribute), ErrorMessageResourceName = "Required")]
        [MaxLength(15)]
        public string? TipoDoCadastro { get; set; }

        public TipoPessoaEnum TesteEnum { get; set; }

        public bool Leitura { get; set; }

        /// <summary>
        /// Usada na GRID
        /// </summary>
        [NotMapped]
        [Display(Name = "Tipo de Cadastro")]
        public string TipoDoCadastroText
        {
            get
            {
               return TipoDoCadastro.GetEnum<TipoStatusEnum>().GetEnumText();
            }
        }

        [NotMapped]
        [Display(Name = "Uso interno")]
        public string? LeituraText
        {
            get
            {
                return (Leitura) ? "SIM" : "NÃO";
            }
        }
    }
}