using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Operacional
{
    public class EntradaEstoque : EntityBase
    {
        public string IdTransacao { get; set; }
        public string IdEstoque { get; set; }
        public string IdOrdemServico { get; set; }
        public string IdStatus { get; set; }
        public string IdUsuario { get; set; }
        public DateTime Data { get; set; }

        public TipoEntrada TipoEntrada { get; set; }

        #region Relacionamentos

        [ForeignKey("IdEstoque")]
        public virtual Estoque Estoque { get; set; }

        [ForeignKey("IdOrdemServico")]
        public virtual OrdemServico OrdemServico { get; set; }

        [ForeignKey("IdStatus")]
        public virtual Status Status { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        #endregion Relacionamentos

        #region CUSTOMGRID

        [NotMapped]
        [Display(Name = "Número")]
        public string NumeroOrdemServico
        {
            get
            {
                var numero = "";

                if (TipoEntrada == TipoEntrada.OrdemServico)
                    numero = OrdemServico != null ? OrdemServico.NumeroDaOS : "";

                return numero;
            }
        }

        [NotMapped]
        public string Evento
        {
            get
            {
                var evento = "";

                if (TipoEntrada == TipoEntrada.OrdemServico)
                    evento = OrdemServico != null ? OrdemServico.Nome : "";

                return evento;
            }
        }

        [NotMapped]
        [Display(Name = "Usuário")]
        public string UsuarioNome
        {
            get
            {
                return Usuario != null ? Usuario.Nome : "";
            }
        }

        [NotMapped]
        [Display(Name = "Data")]
        public string DataFormatada
        {
            get
            {
                return Data.ToString("dd/MM/yyyy HH:mm");
            }
        }

        [NotMapped]
        public string Cliente
        {
            get
            {
                return OrdemServico != null ? OrdemServico.ClienteNome : "";
            }
        }

        [NotMapped]
        [Display(Name = "Tipo Entrada")]
        public string TipoEntradaText
        {
            get
            {
                return TipoEntrada.GetEnumText();
            }
        }

        #endregion CUSTOMGRID

        public override string ToString()
        {
            return string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                Id, IdTransacao, IdEstoque, IdOrdemServico, IdStatus,
                IdUsuario, Data.ToString("yyyy-MM-dd HH:mm:ss"), (int)TipoEntrada);
        }
    }
}