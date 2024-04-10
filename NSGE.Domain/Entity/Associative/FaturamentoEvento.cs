using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class FaturamentoEvento : EntityBase
    {
        public string IdFaturamento { get; set; }
        public string IdEvento { get; set; }

        #region RELACIONAMENTO

        [ForeignKey("IdFaturamento")]
        public virtual Faturamento Faturamento { get; set; }

        [ForeignKey("IdEvento")]
        public virtual Evento Evento { get; set; }

        #endregion RELACIONAMENTO

        public dynamic ConvertJson()
        {
            var display = string.Format("{0} | {1}", this.Evento.NumeroDaOS, this.Evento.Nome);

            dynamic json = this.Evento.ConvertToJson();

            json.DisplaySearch = display;

            return json;
        }
    }
}