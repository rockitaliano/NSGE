using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Models
{
    public class TecnicoDia : EntityBase
    {
        public string AgendaId { get; set; }
        public string TecnicoId { get; set; }
        public double ValorDiaria { get; set; }
        public double ValorAlimentacao { get; set; }

        public bool DiariaPG { get; set; }
        public bool AlimentacaoPG { get; set; }
        public TipoFuncaoPessoaEnum Tipo { get; set; }

        [ForeignKey("AgendaId")]
        public virtual AgendaTecnica Agenda { get; set; }

        [ForeignKey("TecnicoId")]
        public virtual Pessoa Tecnico { get; set; }
    }
}