using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Dtos
{
    public class OrdemServicoGrid : EntityBase
    {
        public string? NumeroDaOS { get; set; }
        public string? Nome { get; set; }
        public string? NomeCliente { get; set; }
        public DateTime? InicioDoEvento { get; set; }

        [NotMapped]
        [Display(Name = "Data do Evento")]
        public string DataEventoFormatada
        {
            get
            {
                return this.InicioDoEvento.HasValue ? this.InicioDoEvento.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }
    }
}