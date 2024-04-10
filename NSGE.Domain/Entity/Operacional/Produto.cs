using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Operacional
{
    public class Produto : EntityBase
    {
        [StringLength(32)]
        public string? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Produto Parent { get; set; }

        [StringLength(32)]
        [Display(Name = "Status")]
        [Required(ErrorMessageResourceName = "Required")]
        public string? IdStatus { get; set; }

        [ForeignKey("IdStatus")]
        public Status Status { get; set; }

        [StringLength(32)]
        [Display(Name = "Fabricante")]
        public string? IdFabricante { get; set; }

        [ForeignKey("IdFabricante")]
        public  Fabricante Fabricante { get; set; }

        [Required(ErrorMessageResourceName = "Required")]
        public string? Nome { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Display(Name = "Observação")]
        public string? Observacao { get; set; }

        public DateTime DataDeCadastro { get; set; }

        [NotMapped]
        public int Nivel { get; set; }
    }
}