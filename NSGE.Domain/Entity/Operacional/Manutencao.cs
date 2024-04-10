using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Entity.Operacional
{
    public class Manutencao : EntityBase
    {
        public string? Produto { get; set; }
        public int Patrimonio { get; set; }
        public string? Status { get; set; }
        public ManutencaoPrioridadeEnum Prioridade { get; set; }               
        
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public string? Criado { get; set; }
        public string? Problema { get; set; }
        public string? Solucao { get; set; }
        public string? Pecas { get; set; }

        [NotMapped]
        [Display(Name = "Data do Entrada")]
        public string DataEntradaFormatada
        {
            get
            {
                return this.Entrada.HasValue ? this.Entrada.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }

        [NotMapped]
        [Display(Name = "Data da Saida")]
        public string DataSaidaFormatada
        {
            get
            {
                return this.Saida.HasValue ? this.Saida.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }

        [NotMapped]
        [Display(Name = "Prioridade")]
        public string? TipoPrioridadeText
        {
            get
            {
                return  Prioridade.GetEnumValue().ToString();
            }
        } 
    }

    
}