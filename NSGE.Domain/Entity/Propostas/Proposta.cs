using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace NSGE.Domain.Entity.Propostas
{
    public class Proposta : EntityBase
    {
        public Proposta()
        {
            Data = DateTime.Now;
            dataenvioemail = null;            
        }
                
        public int? NumeroDaProposta { get; set; }
        public string? Evento { get; set; } = string.Empty;
        public string? Cliente { get; set; } = string.Empty;
        public DateTime? Data { get; set; }
        public DateTime? DataDoEvento { get; set; }
        public string? Equipamento { get; set; } = string.Empty;
        public string? IdDoFuncionario { get; set; } = string.Empty;
        public double? ValorTotal { get; set; } = 0;
        public double? UltimaRevisao { get; set; } = 0;
        public string? NomeDoContato { get; set; }
        public string? DDD { get; set; }  = string.Empty;
        public string? Numero { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public bool MalaDireta { get; set; }
        public string? IdStatus { get; set; }
        public string? Observacao { get; set; } = string.Empty;
        public string? Nome { get; set; } = string.Empty;
        public DateTime? dataenvioemail { get; set; }
                

        [NotMapped]
        public string ValorTotalGeral { get; set; }

        #region Relacionamentos

        [ForeignKey("IdStatus")]
        public Status Status { get; set; }

        [ForeignKey("IdDoFuncionario")]
        public Pessoa Vendedor { get; set; }

        #endregion Relacionamentos

        #region GRID



        [NotMapped]
        public string DataFormatado
        {
            get
            {
                return this.Data.Value.ToShortDateString();
            }
        }

        [NotMapped]
        public string DataDoEventoFormatado
        {
            get
            {
                if (this.DataDoEvento.HasValue)
                    return this.DataDoEvento.Value.ToShortDateString();
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

                if (ValorTotal.HasValue)
                    valor = ValorTotal.Value.ToString("C2",
                  CultureInfo.CreateSpecificCulture("pt-br"));

                return valor;
            }
        }

        [NotMapped]
        public string? UltimaRevisaoFormatado
        {
            get
            {
                var valor = "R$ 0,00";

                if (UltimaRevisao.HasValue)
                    valor = UltimaRevisao.Value.ToString("C2",
                  CultureInfo.CreateSpecificCulture("pt-br"));

                return valor;
            }
        }

        public StatusProposta StatusProposta
        {
            get
            {
                var status = StatusProposta.Aberto;

                if (IdStatus == "04fb8f8bf41d11e7a0d00a002700001a")
                    status = StatusProposta.Fechado;
                else if (IdStatus == "0504df8bf41d11e7a0d00a002700001a")
                    status = StatusProposta.NaoFechado;

                return status;
            }
        }

        #endregion GRID

        public void Atualizar(Proposta model)
        {
            NumeroDaProposta = model.NumeroDaProposta;
            Evento = model.Evento;
            Cliente = model.Cliente;
            Data = model.Data;
            DataDoEvento = model.DataDoEvento;
            Equipamento = model.Equipamento;
            IdDoFuncionario = model.IdDoFuncionario;
            Nome = model.Nome;
            ValorTotal = model.ValorTotal;
            UltimaRevisao = model.UltimaRevisao;
            NomeDoContato = model.NomeDoContato;
            DDD = model.DDD;
            Numero = model.Numero;
            Email = model.Email;
            MalaDireta = model.MalaDireta;
            IdStatus = model.IdStatus;
            //Status = null;
            Observacao = model.Observacao;
        }

        public void AtualizarStatus(Proposta model)
        {
            IdStatus = model.IdStatus;
        }

        
    }
}