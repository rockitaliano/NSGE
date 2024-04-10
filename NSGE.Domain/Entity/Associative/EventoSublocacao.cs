using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class EventoSublocacao : EntityBase
    {
        public string IdEvento { get; set; }
        public string IdSublocadora { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public DateTime DataDeCadastro { get; set; }

        #region Relacionamentos

        [ForeignKey("IdEvento")]
        public virtual Evento Evento { get; set; }

        [ForeignKey("IdSublocadora")]
        public virtual Pessoa Sublocadora { get; set; }

        #endregion Relacionamentos

        #region GRID

        [NotMapped, Display(Name = "Data")]
        public string DataFormatada
        {
            get
            {
                return (Evento?.InicioDoEvento.HasValue).GetValueOrDefault() ?
                                Evento.InicioDoEvento.Value.ToString("dd/MM/yyyy") : "";
            }
        }

        [NotMapped, Display(Name = "Valor")]
        public string ValorFormatado
        {
            get
            {
                return Valor.ToString("C2");
            }
        }

        [NotMapped, Display(Name = "Sublocadora")]
        public string SublocadoraNome
        {
            get
            {
                var value = "";

                if (this.Sublocadora != null)
                    value = !string.IsNullOrEmpty(this.Sublocadora.NomeFantasia) ? this.Sublocadora.Nome + " (" + this.Sublocadora.Nome + ")" : this.Sublocadora.Nome;

                return value;
            }
        }

        [NotMapped, Display(Name = "Evento")]
        public string EventoNome
        {
            get
            {
                var value = "";

                if (this.Evento != null)
                    value = this.Evento.Nome;

                return value;
            }
        }

        [NotMapped, Display(Name = "Numero da OS")]
        public string EventoNumeroOS
        {
            get
            {
                var value = "";

                if (this.Evento != null)
                    value = this.Evento.NumeroDaOS;

                return value;
            }
        }

        #endregion GRID
    }
}