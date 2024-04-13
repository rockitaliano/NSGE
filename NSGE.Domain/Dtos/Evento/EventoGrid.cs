using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Dtos.Evento
{
    public class EventoGrid : EntityBase
    {
        public EventoGrid()
        {
            DataEvento = null;
        }
        public string? NumeroDaOs { get; set; }
        public string? NomeEvento { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataEvento { get; set; }
        public string? Endereco { get; set; }

        [NotMapped]
        [Display(Name = "Data do Evento")]
        public string? DataEventoFormatada
        {
            get
            {
                return this.DataEvento.HasValue ? this.DataEvento.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }
    }
}