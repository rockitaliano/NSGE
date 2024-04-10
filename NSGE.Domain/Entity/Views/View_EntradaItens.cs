using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NSGE.CrosCutting.Enum;

namespace NSGE.Domain.Entity.Views
{
    public class View_EntradaItens : EntityBase
    {
        public string IdTransacao { get; set; }

        [Display(Name = "Número da OS")]
        public string? NumeroDaOS { get; set; }

        public string? Evento { get; set; }

        public string? Cliente { get; set; }

        [Display(Name = "Usuário")]
        public string? Usuario { get; set; }

        public DateTime Data { get; set; }

        public string? Produto { get; set; }
        public int? CodigoInterno { get; set; }

        public int Quantidade { get; set; }

        public string? Status { get; set; }

        public TipoEntrada TipoEntrada { get; set; }

        public string? Tabela { get; set; }
        public List<View_EntradaItens>? Resultados { get; set; }

        #region CUSTOMGRID
        [NotMapped]
        [Display(Name = "Número da OS")]
        public string? NumeroDaOS_Grid
        {
            get
            {
                return TipoEntrada == TipoEntrada.OrdemServico ? NumeroDaOS : "";
            }

        }

        [NotMapped]
        [Display(Name = "Evento")]
        public string? Evento_Grid
        {
            get
            {
                return TipoEntrada == TipoEntrada.OrdemServico ? Evento : "";
            }

        }

        [NotMapped]
        [Display(Name = "Cliente")]
        public string? Cliente_Grid
        {
            get
            {
                return TipoEntrada == TipoEntrada.OrdemServico ? Cliente : "";
            }

        }

        [NotMapped]
        [Display(Name = "Tipo de Entrada")]
        public string? TipoEntrada_Grid
        {
            get
            {
                return TipoEntrada.GetEnumValue();
            }
        }

        [NotMapped]
        [Display(Name = "Data")]
        public string? DataFormatada
        {
            get
            {
                return Data.ToString("dd/MM/yyyy HH:mm");
            }

        }
        #endregion
    }
}