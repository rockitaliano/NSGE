using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models
{
    public class Endereco : EntityBase
    {
        #region Propriedades
        [RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber" )]
        [StringLength(8, MinimumLength = 8, ErrorMessageResourceName = "FixedLength" )]
        public string CEP { get; set; }

        [Required(ErrorMessageResourceName = "Required" )]
        [StringLength(255, ErrorMessageResourceName = "StringLength" )]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        [StringLength(6, ErrorMessageResourceName = "StringLength" )]
        public string Numero { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength" )]
        public string Complemento { get; set; }

        //[Required(ErrorMessageResourceName="Required" )]
        [StringLength(80, ErrorMessageResourceName = "StringLength" )]
        public string Bairro { get; set; }

        //[Required(ErrorMessageResourceName="Required" )]
        [StringLength(30, ErrorMessageResourceName = "StringLength" )]
        public string Cidade { get; set; }

        //[Required(ErrorMessageResourceName="Required" )]
        [StringLength(2, ErrorMessageResourceName = "StringLength" )]
        public string UF { get; set; }

        public bool Principal { get; set; }
        public bool Registro { get; set; }
        [Display(Name = "Cobrança")]
        public bool Cobranca { get; set; }
        public bool Entrega { get; set; }
        public bool Faturamento { get; set; }
        public bool Evento { get; set; }
        #endregion

        #region Propriedades Não Mapeadas
        [NotMapped]
        public bool isDeleted { get; set; }

        [NotMapped]
        public string isPrincipal
        {
            get
            {
                var isPrincipal = "";


                if (Principal == true)
                    isPrincipal = "Principal";

                return isPrincipal;
            }
        }

        [NotMapped]
        public string EnderecoCompleto
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
                if (!string.IsNullOrEmpty(CEP))
                    end += String.Format("{0:00000-000}", Convert.ToInt64(CEP));

                return end.Remove(end.LastIndexOf(", "));
            }
        }

        [NotMapped]
        public string Tipo
        {
            get
            {
                var list = new List<string>();

                if (this.Cobranca)
                    list.Add("Cobrança");
                if (this.Entrega)
                    list.Add("Entrega");
                if (this.Evento)
                    list.Add("Evento");
                if (this.Faturamento)
                    list.Add("Faturamento");

                return string.Join(", ", list);
            }
        }
        #endregion

        #region Contrutores
        public Endereco()
        {
            Bairro = "";
            Cidade = "";
            UF = "";
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica se pelo menos uma flag foi setada
        /// </summary>
        /// <returns></returns>
        public bool hasTypeChecked()
        {
            return Registro || Cobranca || Entrega || Faturamento || Evento;
        }

        public string GetLogradouroCompleto()
        {
            var logradouro = Logradouro ?? "";
            var numero = Numero ?? "";
            var complemento = Complemento ?? "";

            if (!string.IsNullOrEmpty(logradouro) && !string.IsNullOrEmpty(numero))
                logradouro = string.Format("{0}, {1}", logradouro, numero);
            if (!string.IsNullOrEmpty(complemento))
                logradouro = string.Format("{0}, {1}", logradouro, complemento);

            return logradouro;
        }
        #endregion
    }
}