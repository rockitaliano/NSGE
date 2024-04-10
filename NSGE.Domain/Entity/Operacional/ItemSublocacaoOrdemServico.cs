using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Operacional
{
    public class ItemSublocacaoOrdemServico : EntityBase
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public string IdSublocadora { get; set; }
        public string IdOrdemServico { get; set; }
        public string IdUsuario { get; set; }
        public DateTime Data { get; set; }
        public int Entraram { get; private set; }

        #region RELACIONAMENTOS

        [ForeignKey("IdOrdemServico")]
        public virtual OrdemServico OrdemServico { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("IdSublocadora")]
        public virtual Source Sublocadora { get; set; }

        #endregion RELACIONAMENTOS

        public bool isValid()
        {
            return
                !string.IsNullOrEmpty(Produto) &&
                !string.IsNullOrEmpty(IdSublocadora) &&
                !string.IsNullOrEmpty(IdOrdemServico) &&
                Quantidade > 0;
        }

        public int QuantidadeLocada()
        {
            return Quantidade - Entraram;
        }

        public int DarEntrada(int qtd)
        {
            if (qtd < 0)
                return 0;

            int qtdLocada = QuantidadeLocada();

            if (qtd > qtdLocada)
            {
                qtd = qtdLocada;
                Entraram += qtdLocada;
            }
            else
                Entraram += qtd;

            return qtd;
        }

        /// <summary>
        /// update ItemSublocacaoOrdemServico set Entraram = {0} where Id = '{1}';
        /// </summary>
        /// <returns></returns>
        public string SqlUpdateEntrada()
        {
            return string.Format("update ItemSublocacaoOrdemServico set Entraram = {0} where Id = '{1}';", Entraram, Id);
        }
    }
}