using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace NSGE.Domain.Entity.Propostas.Dtos
{
    public class PropostaDTO : EntityBase
    {
        public PropostaDTO()
        {
            Data = DateTime.Now;
            dataenvioemail = null;            
        }
        public string? IdProposta { get; set; }
        public string? IdStatus { get; set; }
        public string? IdDoFuncionario { get; set; }
        public int? NumeroDaProposta { get; set; }
        public string Cliente { get; set; }
        public string? Equipamento { get; set; }
        public string? Evento { get; set; }
        public DateTime? DataDoEvento { get; set; }

        [DisplayFormat(DataFormatString = "DD/MM/YYYY")]
        public DateTime? Data { get; set; }

        //public string? Nome { get; set; }
        //public StatusProposta? StatusProposta { get; set; }
        public decimal? ValorTotal { get; set; }
        public string? valorTotalTeste { get; set; }

        public decimal? UltimaRevisao { get; set; }
        public string? UltimaRevisaoTeste { get; set; }
        public string? NomeDoContato { get; set; }
        public string? DDD { get; set; }
        public string? Numero { get; set; }
        public string? Email { get; set; }
        public string? Observacao { get; set; }
        public bool MalaDireta { get; set; }
        public DateTime? dataenvioemail { get; set; } = null;
        public string? Nome { get; set; }
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

        #region Relacionamentos

        //[ForeignKey("IdStatus")]
        //public virtual Status Status { get; set; }
        //[ForeignKey("IdDoFuncionario")]
        //public Pessoa Vendedor { get; set; }

        #endregion Relacionamentos

        [NotMapped]
        [Display(Name = "Data do Evento")]
        public string DataEventoFormatada
        {
            get
            {
                return this.DataDoEvento.HasValue ? this.DataDoEvento.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }

        #region GRID
        
        [NotMapped]
        public string DataFormatado
        {
            get
            {
                if (Data != null)
                {
                    return Data.Value.ToShortDateString();
                }
                else { return DateTime.Now.ToString(); }
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
        public string UltimaRevisaoFormatado
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

        #endregion GRID

        public void Atualizar(PropostaDTO model)
        {
            Id = model.Id;
            NumeroDaProposta = model.NumeroDaProposta;
            Evento = model.Evento;
            Cliente = model.Cliente;
            Data = model.Data;
            DataDoEvento = model.DataDoEvento;
            Equipamento = model.Equipamento;
            IdDoFuncionario = model.IdDoFuncionario;
            //Vendedor = model.Vendedor;
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