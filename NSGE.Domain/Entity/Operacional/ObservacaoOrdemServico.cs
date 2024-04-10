using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Operacional
{
    public class ObservacaoOrdemServico : EntityBase
    {
        public string IdOrdemServico { get; set; }

        public string IdUsuario { get; set; }

        public string TextoNovo { get; set; }

        public DateTime Data { get; set; }

        #region RELACIONAMENTOS

        [ForeignKey("IdOrdemServico")]
        public virtual OrdemServico OrdemServico { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        #endregion
    }
}