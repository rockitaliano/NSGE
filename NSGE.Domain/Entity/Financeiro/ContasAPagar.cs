using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.CrosCutting.Messages;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;

namespace NSGE.Domain.Entity
{
    public class ContasAPagar : EntityBase
    {
        public ContasAPagar()
        {
            this.QtdParcela = 1;
            this.QtdDias = 30;
        }

        #region Propriedades

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDoCentroDeCusto { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDoPlanoDeConta { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDoStatus { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDaPessoa { get; set; }

        public string IdDaEmpresa { get; set; }
        public string IdDoBanco { get; set; }
        public string IdDaContaCorrente { get; set; }
        public string IdDoFuncionario { get; set; }
        public string IdDaOrdemDeCompra { get; set; }
        public string IdDoUsuario { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public DateTime? DataDeEmissao { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public DateTime? DataDeVencimento { get; set; }

        /// <summary>
        /// Preenchido pelo sistema quando o valor pago está preenchido
        /// </summary>
        public DateTime? DataDoPagamento { get; set; }

        public TipoDocumento? TipoDeDocumento { get; set; }

        public TipoDocumento? TipoDeDocumentoPagamento { get; set; }

        [Display(Name = "Nº Documento")]
        public string NumeroDoDocumento { get; set; }

        [Display(Name = "Nº Documento")]
        public string NumeroDoDocumentoPagamento { get; set; }

        public string NumeroDoBoleto { get; set; }

        public string NumeroDaParcela { get; set; }

        public double? ValorPrevisto { get; set; }
        public double? ValorPago { get; set; }
        public double? ValorDaMulta { get; set; }
        public double? ValorDeJuros { get; set; }
        public double? ValorDesconto { get; set; }

        public string NumeroNotaFiscal { get; set; }
        public double? ValorNotaFiscal { get; set; }

        public string OBS { get; set; }

        public DateTime DataDeCadastro { get; set; }
        public DateTime? DataDeAlteracao { get; set; }

        [NotMapped]
        [Range(1, 999, ErrorMessage = "De 1 a 999")]
        public int QtdParcela { get; set; }

        [NotMapped]
        [Range(1, 999, ErrorMessage = "De 1 a 999")]
        public int QtdDias { get; set; }

        #endregion Propriedades

        #region Relacionamentos

        [ForeignKey("IdDoCentroDeCusto")]
        public virtual CentroDeCusto CentroDeCusto { get; set; }

        [ForeignKey("IdDoPlanoDeConta")]
        public virtual PlanoDeContas PlanoDeConta { get; set; }

        [ForeignKey("IdDoStatus")]
        public virtual Status Status { get; set; }

        [ForeignKey("IdDaPessoa")]
        public Pessoa Pessoa { get; set; }

        [ForeignKey("IdDaEmpresa")]
        public virtual Empresa Empresa { get; set; }

        [ForeignKey("IdDoBanco")]
        public virtual Banco Banco { get; set; }

        [ForeignKey("IdDaContaCorrente")]
        public virtual ContaCorrente ContaCorrente { get; set; }

        [ForeignKey("IdDoFuncionario")]
        public virtual Pessoa Funcionario { get; set; }

        [ForeignKey("IdDoUsuario")]
        public virtual Usuario Usuario { get; set; }

        #endregion Relacionamentos

        #region Campos de pesquisa

        //[NotMapped]
        //public string PesquisaPessoa
        //{
        //    get
        //    {
        //        var result = "";

        //        try
        //        {
        //            if (Pessoa != null)
        //                result = Pessoa.Nome;
        //            else
        //                result = HttpContext.Request.Form["pesquisar-pessoas"];
        //        }
        //        catch
        //        {
        //        }

        //        return result;
        //    }
        //}

        //[NotMapped]
        //public string PesquisaColaborador
        //{
        //    get
        //    {
        //        var result = "";

        //        try
        //        {
        //            if (Funcionario != null)
        //                result = Funcionario.Nome;
        //            else
        //                result = HttpContext.Request.Form["pesquisar-colaboradores"];
        //        }
        //        catch
        //        {
        //        }

        //        return result;
        //    }
        //}

        #endregion Campos de pesquisa

        #region GRID

        [NotMapped, Display(Name = "Vencimento")]
        public string VencimentoFormatado
        {
            get
            {
                return this.DataDeVencimento.Value.ToShortDateString();
            }
        }

        [NotMapped, Display(Name = "Fornecedor/Funcionário")]
        public string PessoaNome
        {
            get
            {
                var nome = "";

                if (Pessoa != null)
                    nome = Pessoa.Nome;

                return nome;
            }
        }

        [NotMapped, Display(Name = "Valor Pago")]
        public string ValorPagoFormatado
        {
            get
            {
                var valor = "R$ 0,00";

                if (ValorPago.HasValue)
                    valor = ValorPago.Value.ToString("C2");

                return valor;
            }
        }

        [NotMapped, Display(Name = "Valor Previsto")]
        public string ValorPrevistoFormatado
        {
            get
            {
                var valor = "R$ 0,00";

                if (ValorPrevisto.HasValue)
                    valor = ValorPrevisto.Value.ToString("C2");

                return valor;
            }
        }

        public StatusPagamento StatusPagamento
        {
            get
            {
                var status = StatusPagamento.EmAberto;

                if (ValorPago.HasValue && ValorPago.Value > 0)
                    status = StatusPagamento.Pago;
                else if (DataDeVencimento.HasValue && DateTime.Now.Date > DataDeVencimento)
                    status = StatusPagamento.Vencido;

                return status;
            }
        }

        #endregion GRID

        public ContasAPagarFiltro Filtro { get; set; }


        //public new ContasAPagar Clone()
        //{
        //    return (ContasAPagar)base.Clone();
        //}
    }
}