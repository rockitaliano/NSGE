using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity
{
    public class DiariaTecnica : EntityBase
    {
        //Id - Id da tabela TecnicoDia

        public string AgendaId { get; set; }

        public string EventoId { get; set; }

        public string TecnicoId { get; set; }

        [Display(Name = "Técnico")]
        public string Tecnico { get; set; }

        public string Evento { get; set; }

        [Display(Name = "Número da OS")]
        public string OS { get; set; }

        public DateTime DataEvento { get; set; }

        public double ValorDiaria { get; set; }
        public double ValorAlimentacao { get; set; }

        public bool DiariaPG { get; set; }
        public bool AlimentacaoPG { get; set; }

        public TipoFuncaoPessoaEnum Tipo { get; set; }

        #region GRID Diaria/Alimentacao

        [NotMapped]
        [Display(Name = "Total Diária")]
        public string TotalDiaria { get; set; }

        [NotMapped]
        [Display(Name = "Total Alimentação")]
        public string TotalAlimentacao { get; set; }

        #endregion GRID Diaria/Alimentacao
    }
}