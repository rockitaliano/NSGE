using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Models
{
    public class Empresa : EntityBase
    {
        #region Dados Principais

        [Display(Name = "Razão Social")]
        //[StringLength(90, ErrorMessageResourceName = "StringLength")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        //[StringLength(90, ErrorMessageResourceName = "StringLength")]
        public string NomeFantasia { get; set; }

        [Display(Name = "CNPJ")]
        //[RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber")]
        //[StringLength(14, MinimumLength = 14, ErrorMessageResourceName = "FixedLength")]
        public string Cnpj { get; set; }

        [Display(Name = "Data de Inscrição")]
        public DateTime? DataInscricao { get; set; }

        [Display(Name = "Incrição Estadual")]
        //[StringLength(15, ErrorMessageResourceName = "StringLength")]
        public string? InscricaoEstadual { get; set; }

        [Display(Name = "Incrição Municipal")]
        //[StringLength(15, ErrorMessageResourceName = "StringLength")]
        public string? InscricaoMunicipal { get; set; }

        [Display(Name = "Código CNAE")]
        //[RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber")]
        public int? CodigoCNAE { get; set; }

        [Display(Name = "Logo")]
        public string? Logo { get; set; }

        #endregion Dados Principais

        #region Endereço

        [Display(Name = "CEP")]
        //[RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber")]
        //[StringLength(8, MinimumLength = 8, ErrorMessageResourceName = "FixedLength")]
        public string CEP { get; set; }

        [Display(Name = "Logradouro")]
        //[StringLength(255, ErrorMessageResourceName = "StringLength")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        //[RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber")]
        //[StringLength(6, ErrorMessageResourceName = "StringLength")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        //[StringLength(50, ErrorMessageResourceName = "StringLength")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        //[StringLength(80, ErrorMessageResourceName = "StringLength")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        //[StringLength(30, ErrorMessageResourceName = "StringLength")]
        public string Cidade { get; set; }

        [Display(Name = "UF")]
        //[StringLength(2, ErrorMessageResourceName = "StringLength")]
        public string? UF { get; set; }

        [NotMapped]
        public string EnderecoBoleto
        {
            get
            {
                var end = "";

                if (!string.IsNullOrEmpty(Logradouro))
                    end += string.Format("{0}, ", Logradouro);
                if (!string.IsNullOrEmpty(Numero))
                    end += string.Format("{0}, ", Numero);
                if (!string.IsNullOrEmpty(Complemento))
                    end += string.Format("{0}, ", Complemento);
                if (!string.IsNullOrEmpty(Bairro))
                    end += string.Format("{0}, ", Bairro);
                if (!string.IsNullOrEmpty(Cidade))
                    end += string.Format("{0}, ", Cidade);
                if (!string.IsNullOrEmpty(UF))
                    end += string.Format("{0}, ", UF);

                return end.Remove(end.LastIndexOf(", "));
            }
        }

        #endregion Endereço

        #region Telefone

        [Display(Name = "DDD")]
        //[RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber")]
        //[StringLength(5, ErrorMessageResourceName = "MaxLength")]
        public string DDD { get; set; }

        [Display(Name = "Telefone")]
        //[RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber")]
        //[StringLength(30, ErrorMessageResourceName = "MaxLength")]
        public string NumeroTel { get; set; }

        [NotMapped]
        public WebHostEnvironment _hostEnvironment { get; set; }

        #endregion Telefone
    }
}