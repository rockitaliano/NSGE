using Microsoft.AspNetCore.Mvc.Rendering;
using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Messages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Models
{
    public class Veiculo : EntityBase
    {
        public Veiculo()
        {
        }

        #region PROPRIEDADES

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Required")]
        [StringLength(32)]
        public string? MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca? Marca { get; set; }

        public string? Modelo { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(50, ErrorMessage = "MaxLength")]
        public string? Descricao { get; set; }

        [StringLength(30, ErrorMessage = "MaxLength")]
        public string Cor { get; set; }

        [Display(Name = "Ano de Fabricação")]
        [Range(1900, 9999, ErrorMessage = "Range")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "RegexNumber")]
        public int? AnoDeFabricacao { get; set; }

        [Display(Name = "Ano do Modelo")]
        [Range(1900, 9999, ErrorMessage = "Range")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "RegexNumber")]
        public int? AnoDoModelo { get; set; }

        [StringLength(9, ErrorMessage = "MaxLength")]
        public string? Placa { get; set; }

        #endregion PROPRIEDADES

        #region NOTMAPPED

        [NotMapped]
        public string? DescricaoDetalhada
        {
            get
            {
                var list = new string[] { MarcaDescricao, Modelo, Cor, Placa };

                return string.Join(" - ", list.Where(x => !string.IsNullOrEmpty(x)).ToArray());
            }
        }

        [NotMapped]
        public IEnumerable<Marca>? MarcasDisponiveis { get; set; }

        public string MarcaDescricao
        {
            get
            {
                return Marca != null ? Marca.Descricao : "";
            }
        }

        #endregion NOTMAPPED

        #region METODOS

        public SelectList MontarDropdown()
        {            
            return new SelectList(MarcasDisponiveis, "Id", "Descricao", this.MarcaId);            
        }

        #endregion METODOS
    }
}