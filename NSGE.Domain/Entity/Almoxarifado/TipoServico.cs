using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;

namespace NSGE.Domain.Entity.Almoxarifado
{
    public class TipoServico : EntityBase
    {
        public string Descricao { get; set; }
        public TipoValor TipoValor { get; set; }
        public double Valor { get; set; }

        public object ToJson()
        {
            var format = TipoValor == TipoValor.Extra ? null : "N2";

            return new
            {
                Id = Id,
                Descricao = Descricao,
                TipoValor = TipoValor.ToString(),
                Valor = Valor.ToString(format)
            };
        }
    }
}