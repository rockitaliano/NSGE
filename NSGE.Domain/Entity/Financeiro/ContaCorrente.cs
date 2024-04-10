using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Messages;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NSGE.CrosCutting.Enum;

namespace NSGE.Domain.Entity.Financeiro
{
    public class ContaCorrente : EntityBase
    {
        public ContaCorrente()
        {
            this.NumeroDoFinalDoNossoNumero = 99999999999;
        }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDoBanco { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDaEmpresa { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        [RegularExpression("^[0-9]+-?[a-zA-z0-9]+$", ErrorMessage = "número inválido")]
        public string Agencia { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        [RegularExpression("^[0-9]+-?[a-zA-z0-9]+$", ErrorMessage = "número inválido")]
        public string NumeroDaConta { get; set; }

        public string Variacao { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string CodigoCedente { get; set; }
        public TipoBoleto? TipoDocumentoBoleto { get; set; }
        public bool CarteiraCadastrada { get; set; }

        [Range(0, 100, ErrorMessage = "valor dever ser entre 0 e 100")]
        public double? PercentualDeMulta { get; set; }

        [Range(0, 100, ErrorMessage = "valor dever ser entre 0 e 100")]
        public double? PercentualDeJuros { get; set; }
        public double? ValorDeJuros { get; set; }
        public int? NumeroDeDiasDeJuros { get; set; }

        public string MensagemDoBoleto { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        [Range(0, 99999999999, ErrorMessage = "Deve ter no máximo 11 digitos")]
        public long NumeroDoInicioDoNossoNumero { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        [Range(1, 99999999999, ErrorMessage = "Deve ser maior que 0 e ter no máximo 11 digitos")]
        public long NumeroDoFinalDoNossoNumero { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        [Range(0, 99999999999, ErrorMessage = "Deve ter no máximo 11 digitos")]
        public long NumeroAtualDoNossoNumero { get; set; }


        [ForeignKey("IdDoBanco")]
        public virtual Banco Banco { get; set; }

        public string NomeBanco { get; set; }   

        //[ForeignKey("IdDaEmpresa")]
        //public virtual Empresa Empresa { get; set; }
        public string Empresa { get; set; }


        public bool HasFilterValues()
        {
            return !string.IsNullOrEmpty(this.IdDaEmpresa) ||
                (this.Banco != null && !string.IsNullOrEmpty(this.Banco.Descricao)) ||
                !string.IsNullOrEmpty(this.Agencia) ||
                !string.IsNullOrEmpty(this.NumeroDaConta);
        }

        public long IncrementarNumeroAtual()
        {
            NumeroAtualDoNossoNumero += 1;

            if (NumeroAtualDoNossoNumero > NumeroDoFinalDoNossoNumero)
                NumeroAtualDoNossoNumero = NumeroDoInicioDoNossoNumero;

            return NumeroAtualDoNossoNumero;
        }
    }
}