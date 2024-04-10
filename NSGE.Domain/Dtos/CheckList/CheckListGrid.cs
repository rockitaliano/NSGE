using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Dtos.CheckList
{
    public class CheckListGrid : EntityBase
    {
        public bool Aprovado { get; set; }
        public string? NumeroDaOs { get; set; }
        public string? Nome { get; set; }
        public string? NomeCliente { get; set; }
        public DateTime? DataEvento { get; set; }
        public DateTime? DataDaMontagem { get; set; }

        [NotMapped]
        [Display(Name = "Data do Evento")]
        public string DataEventoFormatada
        {
            get
            {
                return this.DataEvento.HasValue ? this.DataEvento.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }

        [NotMapped]
        [Display(Name = "Data do Evento")]
        public string DataMontagemFormatada
        {
            get
            {
                return this.DataDaMontagem.HasValue ? this.DataDaMontagem.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }

        [NotMapped]
        [Display(Name = "Aprovado")]
        public string ApovadoTratuzido
        {
            get
            {
                return Aprovado ? "Aprovado" : "Não Aprovado";
            }
        }
    }
}