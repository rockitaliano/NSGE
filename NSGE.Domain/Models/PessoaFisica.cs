using NSGE.CrosCutting.Messages;
using NSGE.Domain.Entity.Interface;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models
{
    /// <summary>
    /// Classe usada para sobrescrever validações específicas
    /// </summary>
    public class PessoaFisica : Pessoa, IPessoa
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string? Nome { get; set; }

        [Display(Name = "Nome do Pai")]
        public string NomePai { get; set; }

        [Display(Name = "Nome da Mãe")]
        public string NomeMae { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessageResourceName = "FixedLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string? Documento { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "RG")]
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Identidade { get; set; }

        [Display(Name = "Órgão Expedidor")]
        [StringLength(20, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Orgao { get; set; }

        [Display(Name = "Data de Emissão")]
        public DateTime? DataDeEmissao { get; set; }

        [StringLength(1, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Sexo { get; set; }

        [Display(Name = "Estado Civil")]
        [StringLength(1, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string EstadoCivil { get; set; }

        [Display(Name = "Profissão")]
        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Profissao { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Naturalidade { get; set; }
       
    }
}