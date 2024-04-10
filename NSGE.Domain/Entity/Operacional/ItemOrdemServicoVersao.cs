using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Operacional
{
    public class ItemOrdemServicoVersao : EntityBase
    {
        public DateTime Data { get; set; }

        public int Status { get; set; }

        public int Versao { get; set; }

        [ForeignKey("IdOrdemServico")]
        public virtual OrdemServico OrdemServico { get; set; }

        public string IdOrdemServico { get; set; }

        [ForeignKey("IdEstoque")]
        public virtual Estoque Estoque { get; set; }

        public string IdEstoque { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        public string IdUsuario { get; set; }
    }
}