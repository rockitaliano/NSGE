using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Operacional
{
    public class ItemSublocacaoOrdemServicoVersao : EntityBase
    {
        public string Produto { get; set; }
        public string IdSublocadora { get; set; }
        public string IdOrdemServico { get; set; }
        public int QuantidadeAntiga { get; set; }
        public int QuantidadeNova { get; set; }
        public int Versao { get; set; }

        public TipoOrdemServicoVersaoStatus Status { get; set; }
        public DateTime Data { get; set; }
        public string IdUsuario { get; set; }

        #region RELACIONAMENTOS

        [ForeignKey("IdSublocadora")]
        public virtual Source Sublocadora { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("IdOrdemServico")]
        public virtual OrdemServico OrdemServico { get; set; }

        #endregion RELACIONAMENTOS
    }
}