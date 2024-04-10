using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Operacional;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Models
{
    public class HistoricoEstoque : EntityBase
    {
        public string IdEstoque { get; set; }
        public string IdOrdemServico { get; set; }
        public string IdStatus { get; set; }
        public DateTime Data { get; set; }
        public TipoHistorico Tipo { get; set; }
        public string IdUsuario { get; set; }

        #region Relacionamentos

        [ForeignKey("IdEstoque")]
        public Estoque? Estoque { get; set; }

        [ForeignKey("IdOrdemServico")]
        public OrdemServico? OrdemServico { get; set; }

        [ForeignKey("IdStatus")]
        public Status? Status { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        public Produto? Produto { get; set; }

        #endregion Relacionamentos

        public string ProdutoNome { get; set; }
        public string CodigoInterno { get; set; }
        public string NumeroDaOs { get; set; }
        public string EventoNome { get; set; }
        public string ClienteNome { get; set; }
        public string StatusDescricao { get; set; }

        public override string ToString()
        {
            return string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                Id, IdEstoque, IdOrdemServico, IdStatus, IdUsuario, Data.ToString("yyyy-MM-dd HH:mm:ss"), (int)Tipo);
        }

        [Display(Name = "Data")]
        public string DataFormatada
        {
            get { return this.Data.ToShortDateString(); }
        }
    }
}