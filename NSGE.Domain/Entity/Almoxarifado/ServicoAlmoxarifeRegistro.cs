using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Almoxarifado
{
    public class ServicoAlmoxarifeRegistro : EntityBase
    {
        public string? ServicoAlmoxarifeId { get; set; }
        public string? TipoServicoId { get; set; }
        public DateTime Data { get; set; }
        public DateTime? DataFim { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }
        public double ValorServico { get; set; }
        public bool ServicoPago { get; set; }
        public double ValorAlimentacao { get; set; }
        public bool AlimentacaoPago { get; set; }

        [ForeignKey("ServicoAlmoxarifeId")]
        public virtual ServicoAlmoxarife? ServicoAlmoxarife { get; set; }

        [ForeignKey("TipoServicoId")]
        public virtual TipoServico? TipoServico { get; set; }


    }
}