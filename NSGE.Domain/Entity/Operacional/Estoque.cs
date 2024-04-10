using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NSGE.CrosCutting.Enum;

namespace NSGE.Domain.Entity.Operacional
{
    public class Estoque : EntityBase
    {
        public Estoque()
        {
            ImagensAdicionadas = new List<string>();
        }

        [StringLength(32)]
        public string IdProduto { get; set; }

        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        [Display(Name = "Status")]
        [StringLength(32)]
        [Required(ErrorMessageResourceName = "Required")]
        public string IdStatus { get; set; }

        [ForeignKey("IdStatus")]
        public Status Status { get; set; }

        [Display(Name = "Empresa")]
        [StringLength(32)]
        public string IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")]
        public Empresa Empresa { get; set; }

        [Display(Name = "Fornecedor")]
        [StringLength(32)]
        public string IdFornecedor { get; set; }

        [ForeignKey("IdFornecedor")]
        public Pessoa Fornecedor { get; set; }

        [StringLength(32)]
        public string? IdNotaFiscal { get; set; }

        [ForeignKey("IdNotaFiscal")]
        public NotaFiscal? NotaFiscal { get; set; }

        /// <summary>
        /// imagens separadas por ";" 
        /// Formato GUID+EXTENSAO;GUID+EXTENSAO
        /// </summary>
        public string Imagens { get; set; }


        [Required(ErrorMessageResourceName = "Required")]
        public OperacionalSetorEnum? Setor { get; set; }

        public string Serial { get; set; }

        [Display(Name = "Código Interno")]
        [RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber")]
        public int? CodigoInterno { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public DateTime DataCadastro { get; set; }

        public Composicao Composicao { get; set; }

        public string Runtime { get; set; }
        [Display(Name = "Último Teste")]
        public DateTime? UltimoTeste { get; set; }
        [Display(Name = "Lâmpada 1")]
        public string Lampada1 { get; set; }
        [Display(Name = "Lâmpada 2")]
        public string Lampada2 { get; set; }
        [Display(Name = "Lâmpada 3")]
        public string Lampada3 { get; set; }
        [Display(Name = "Lâmpada 4")]
        public string Lampada4 { get; set; }

        [Display(Name = "Peso Bruto")]
        [RegularExpression("[0-9]+(,[0-9][0-9][0-9]?)?")]
        public double? PesoBruto { get; set; }

        #region Not Mappeds
        [NotMapped]
        [Display(Name = "Modo de Inserção")]
        [Required()]
        public string Modo { get; set; }

        [NotMapped]
        [Display(Name = "Código Inicial")]
        [Required(ErrorMessageResourceName = "Required")]
        [RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber")]
        public int? CodigoInternoInicial { get; set; }

        [NotMapped]
        [Display(Name = "Código Final")]
        [Required(ErrorMessageResourceName = "Required")]
        [RegularExpression("^[0-9]+$", ErrorMessageResourceName = "RegexNumber")]
        public int? CodigoInternoFinal { get; set; }

        [NotMapped]
        [Required(ErrorMessageResourceName = "Required")]
        [RegularExpression("^[0-9]+$")]
        public int Quantidade { get; set; }

        [NotMapped]
        [Display(Name = "Produto")]
        public string ProdutoNome
        {
            get
            {
                if (Produto == null)
                    return "";

                return Produto.Nome;
            }
        }

        [NotMapped]
        public IList<string> ImagensAdicionadas { get; set; }

        #endregion

        #region UTIL
        public bool isValid()
        {
            return
                !string.IsNullOrEmpty(IdStatus) &&
                !string.IsNullOrEmpty(Modo) &&
                Setor.HasValue &&
                (
                    Modo.Equals("#unico") /* && CodigoInterno.HasValue */ ||
                    Modo.Equals("#sequencial") && ((CodigoInternoInicial.HasValue && CodigoInternoFinal.HasValue) && CodigoInternoInicial < CodigoInternoFinal) ||
                    Modo.Equals("#generico") && Quantidade > 0
                );
        }

       

        //public new Usuario Clone2()
        //{
        //    return (Usuario)base.Clone();
        //}

        public IList<string> RecuperarImagens()
        {
            var list = new List<string>();

            if (!string.IsNullOrEmpty(Imagens))
                list = Imagens.Split(';').ToList();

            return list;
        }
        #endregion

        public virtual ICollection<ItemOrdemServico> ItemOrdemServico { get; set; }
    }
}