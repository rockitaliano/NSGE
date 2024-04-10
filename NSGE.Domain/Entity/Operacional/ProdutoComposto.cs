using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Operacional
{
    public class ProdutoComposto : EntityBase
    {
        [Required()]
        public string IdParent { get; set; }

        [Required()]
        public string IdChild { get; set; }

        [ForeignKey("IdParent")]
        public Estoque Parent { get; set; }

        [ForeignKey("IdChild")]
        public Estoque Child { get; set; }

    }
}