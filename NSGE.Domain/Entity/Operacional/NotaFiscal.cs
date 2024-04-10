using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Entity.Operacional
{
    public class NotaFiscal : EntityBase
    {
        [Display(Name = "Número")]
        public string? Numero { get; set; }

        [Display(Name = "Data de entrada")]
        public DateTime? DataEntrada { get; set; }

        [Display(Name = "Data final garantia")]
        public DateTime? DataFinalGarantia { get; set; }

        [Display(Name = "Valor unitário")]
        [RegularExpression("[0-9]+(,[0-9][0-9]?)?", ErrorMessageResourceName = "RegexMonetario")]
        public double? ValorUnitario { get; set; }

        public bool isValid()
        {
            return
                !string.IsNullOrEmpty(Numero) &&
                (DataEntrada.HasValue && DataFinalGarantia.HasValue) &&
                DataEntrada.Value < DataFinalGarantia.Value &&
                ValorUnitario != null;
        }

        public object ToJson()
        {
            return new
            {
                Numero = Numero,
                DataEntrada = DataEntrada?.ToShortDateString(),
                DataFinalGarantia = DataFinalGarantia?.ToShortDateString(),
                ValorUnitario = ValorUnitario
            };
        }
    }
}