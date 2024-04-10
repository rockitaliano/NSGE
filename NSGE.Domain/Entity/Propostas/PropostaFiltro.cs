using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace NSGE.Domain.Entity.Propostas
{
    public class PropostaFiltro
    {
        public PropostaFiltro()
        {
            InicioEvento = DateTime.Now.Date;            
        }

        public string? Id { get; set; }
        public DateTime? InicioEvento { get; set; }
        public DateTime? FimEvento { get; set; }
        public string IdStatus { get; set; }
        public string IdDoFuncionario { get; set; }
        public string Evento { get; set; }
        public string Cliente { get; set; }
        public int NumeroDaProposta { get; set; }
        public double? Valor { get; set; }

        public StatusProposta? StatusProposta { get; set; }
        public Status? Status { get; set; }
        public Pessoa? Vendedor { get; set; }

        [NotMapped]
        public string DataInicioEventoFormatado
        {
            get
            {
                if (this.InicioEvento.HasValue)
                    return this.InicioEvento.Value.ToShortDateString();
                else
                    return null;
            }
        }

        [NotMapped]
        public string DataFimEventoFormatado
        {
            get
            {
                if (this.FimEvento.HasValue)
                    return this.FimEvento.Value.ToShortDateString();
                else
                    return null;
            }
        }

        [NotMapped, Display(Name = "Valor do Evento")]
        public string ValorDoEventoFormatado
        {
            get
            {
                var valor = "R$ 0,00";

                if (Valor.HasValue)
                    valor = Valor.Value.ToString("C2",
                  CultureInfo.CreateSpecificCulture("pt-br"));

                return valor;
            }
        }

        public bool HasValues()
        {
            return
                InicioEvento.HasValue ||
                FimEvento.HasValue ||
                !string.IsNullOrEmpty(IdStatus) ||
                !string.IsNullOrEmpty(IdDoFuncionario) ||
                !string.IsNullOrEmpty(Evento) ||
                !string.IsNullOrEmpty(Cliente) ||
                !string.IsNullOrEmpty(Convert.ToString(NumeroDaProposta)) ||
                !Valor.HasValue ||
                !StatusProposta.HasValue;
        }
    }
}