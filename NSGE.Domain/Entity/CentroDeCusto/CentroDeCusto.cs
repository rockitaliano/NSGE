using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Entity
{
    public class CentroDeCusto : EntityBase
    {
        public CentroDeCusto()
        {
            ExibirEmContasAPagar = true;
            ExibirEmContasAReceber = true;
        }

        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }

        [Display(Name = "Código")]
        [Required]
        public int? Codigo { get; set; }

        public bool ExibirEmContasAPagar { get; set; }
        public bool ExibirEmContasAReceber { get; set; }

        public virtual ICollection<ContasAPagar> ContasAPagar { get; set; }

        public bool HasValues
        {
            get
            {
                return !string.IsNullOrEmpty(Descricao) || Codigo.HasValue;
            }
        }
    }
}