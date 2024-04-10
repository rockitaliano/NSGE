using NSGE.CrossCutting.BaseEntity;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Auditoria;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Financeiro
{
    public class Faturamento : EntityBase, IAuditoria
    {
        public Faturamento()
        {
            this.Id = "";
            this.DataDeEmissao = DateTime.Now.Date;
            this.DataDeEmissaoFiltro = DateTime.UtcNow;
            this.Parcelas = 1;
            this.ContasAReceber = new List<ContasAReceber>();
            this.Eventos = new List<FaturamentoEvento>();
        }

        public Faturamento(FaturamentoConfiguracoes configuracao) : this()
        {
            SetConfiguracoes(configuracao);
        }

        //[Required(ErrorMessageResourceType = typeof(ResourceScope), ErrorMessageResourceName = "Required")]
        public string IdDoCliente { get; set; }

        public string IdDoEndereco { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        public string IdDoCentroDeCusto { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        public string IdDoPlanoDeConta { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        public string IdDoBanco { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        public string IdDaContaCorrente { get; set; }

        public string IdDoFuncionario { get; set; }

        // [Required(ErrorMessageResourceName = "Required")]
        public string IdDaEmpresa { get; set; }

        // [Required(ErrorMessageResourceName = "Required")]
        public string NumeroDaNotaFiscal { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        public DateTime DataDeEmissao { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        public DateTime? DataDeVencimento { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        public int? IntervaloDeDias { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        [Range(1, 999, ErrorMessage = "Deve ser maior que 0 e menor que 999")]
        public int Parcelas { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        [Range(0.01, 9999999.99, ErrorMessage = "Valor deve ser maior que 0 e menor que 99999999,99")]
        public double? ValorTotal { get; set; }

        public TipoDocumento? TipoDocumento { get; set; }

        public string DescricaoDoServico { get; set; }

        public DateTime DataDeCadastro { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
        public string UsuarioCadastroId { get; set; }
        public string UsuarioAlteracaoId { get; set; }

        // Remover
        //public string IdDoEvento { get; set; }

        #region Relacionamentos

        [ForeignKey("IdDoCliente")]
        public Pessoa Cliente { get; set; }

        public string Clientes { get; set; }

        [ForeignKey("IdDoEndereco")]
        public virtual Endereco ClienteEndereco { get; set; }

        [ForeignKey("IdDoCentroDeCusto")]
        public virtual CentroDeCusto CentroDeCusto { get; set; }

        [ForeignKey("IdDoPlanoDeConta")]
        public virtual PlanoDeContas PlanoDeContas { get; set; }

        [ForeignKey("IdDoBanco")]
        public virtual Banco Banco { get; set; }

        [ForeignKey("IdDaContaCorrente")]
        public virtual ContaCorrente ContaCorrente { get; set; }

        [ForeignKey("IdDoFuncionario")]
        public virtual Pessoa Funcionario { get; set; }

        [ForeignKey("IdDaEmpresa")]
        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<ContasAReceber> ContasAReceber { get; set; }

        #endregion Relacionamentos

        #region Eventos

        public virtual IList<FaturamentoEvento> Eventos { get; set; }

        [NotMapped]
        public string Status { get; set; }

        public void RecuperarJsonStatus()
        {
            this.Status = "Pago";

            foreach (var item in ContasAReceber)
            {
                if (item.ValorPago == 0 || item.ValorPago.Equals(null))
                {
                    this.Status = "Não Pago";
                }
            }
        }

        [NotMapped]
        public string JsonEventoIds { get; set; }

        public void RecuperarJsonEventos()
        {
            if (!string.IsNullOrEmpty(JsonEventoIds))
            {
                var eventoIds = System.Text.Json.JsonSerializer.Deserialize<IList<string>>(JsonEventoIds);

                this.Eventos = eventoIds.Select(x => new FaturamentoEvento() { IdEvento = x, IdFaturamento = this.Id }).ToList();
            }
        }

        [Display(Name = "Evento(s)")]
        public string EventosFormatados
        {
            get
            {
                var eventos = string.Empty;

                if (Eventos != null && Eventos.Count > 0)
                {
                    var resumo = Eventos.OrderBy(x => x.Evento.Nome)
                                        .Select(x => new { Nome = x.Evento.Nome, NumeroDaOS = x.Evento.NumeroDaOS })
                                        .ToList();

                    foreach (var item in resumo)
                    {
                        var row = "";

                        row += string.Format("{0}{1}{2}", item.NumeroDaOS, string.IsNullOrEmpty(item.Nome) ? "" : " - ", item.Nome);

                        eventos += string.Format("{0}<br/>", row);
                    }
                }

                return eventos;
            }
        }

        #endregion Eventos

        #region SomenteLeitura

        //public string ClientePesquisa
        //{
        //    get
        //    {
        //        var result = "";

        //        try
        //        {
        //            if (Cliente != null)
        //                result = Cliente.Nome;
        //            else
        //                result = System.Web.HttpContext.Current.Request.Form["ClientePesquisa"];
        //        }
        //        catch
        //        {
        //        }

        //        return result;
        //    }
        //}

        //public string FuncionarioPesquisa
        //{
        //    get
        //    {
        //        var result = "";

        //        try
        //        {
        //            if (Funcionario != null)
        //                result = Funcionario.Nome;
        //            else
        //                result = System.Web.HttpContext.Current.Request.Form["FuncionarioPesquisa"];
        //        }
        //        catch
        //        {
        //        }

        //        return result;
        //    }
        //}

        #endregion SomenteLeitura

        #region Filtro

        [NotMapped]
        public string ClienteNome { get; set; }

        [NotMapped]
        public string FuncionarioNome { get; set; }

        [NotMapped]
        public DateTime? DataDeEmissaoFiltro { get; set; }

        #endregion Filtro

        public void Validar()
        {
            if (this.DataDeEmissao > this.DataDeVencimento)
                throw new NSGECustomException("Não pode ser menor que a emissão", "DataDeVencimento");
        }

        public void SetConfiguracoes(FaturamentoConfiguracoes configuracao)
        {
            if (configuracao != null)
            {
                this.IntervaloDeDias = configuracao.IntervaloDeDias;
                this.DataDeVencimento = DateTime.Now.Date.AddDays(configuracao.IntervaloDeDias);
                this.NumeroDaNotaFiscal = (configuracao.NumeroDaNotaFiscal + 1).ToString();
                this.DescricaoDoServico = configuracao.DescricaoDoServico;
            }
        }

        [NotMapped]
        public string DataFormatado
        {
            get
            {
                if (DataDeEmissao != null)
                {
                    return DataDeEmissao.ToShortDateString();
                }
                else { return DateTime.Now.ToString(); }
            }
        }
    }
}