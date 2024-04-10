using NSGE.CrossCutting.BaseEntity;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Enum;
using NSGE.CrosCutting.Messages;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Financeiro
{
    public class ContasAReceber : EntityBase
    {
        #region Propriedades

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDoCentroDeCusto { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDoPlanoDeConta { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDoStatus { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string IdDoCliente { get; set; }

        public string IdDaEmpresa { get; set; }
        public string IdDoBanco { get; set; }
        public string IdDaContaCorrente { get; set; }
        public string IdDoFuncionario { get; set; }
        public string IdDaFatura { get; set; }
        public string IdDoUsuario { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public DateTime? DataDeEmissao { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public DateTime? DataDeVencimento { get; set; }

        public DateTime? DataDoRecebimento { get; set; }

        public TipoDocumento? TipoDeDocumento { get; set; }

        public TipoDocumento? TipoDeDocumentoRecebimento { get; set; }

        [Display(Name = "Nº Documento")]
        public string NumeroDoDocumento { get; set; }

        [Display(Name = "Nº Documento")]
        public string NumeroDoDocumentoRecebimento { get; set; }

        public string NumeroDoBoleto { get; set; }

        public string NumeroDaParcela { get; set; }

        public double? ValorPrevisto { get; set; }
        public double? ValorPago { get; set; }
        public double? ValorDaMulta { get; set; }
        public double? ValorDeJuros { get; set; }
        public double? ValorDesconto { get; set; }

        public double? ValorNotaFiscal { get; set; }

        public string OBS { get; set; }

        public DateTime DataDeCadastro { get; set; }
        public DateTime? DataDeAlteracao { get; set; }

        #endregion Propriedades

        #region Relacionamentos

        [ForeignKey("IdDoCentroDeCusto")]
        public virtual CentroDeCusto CentroDeCusto { get; set; }

        [ForeignKey("IdDoPlanoDeConta")]
        public virtual PlanoDeContas PlanoDeConta { get; set; }

        [ForeignKey("IdDoStatus")]
        public virtual Status Status { get; set; }

        [ForeignKey("IdDoCliente")]
        public virtual Pessoa Cliente { get; set; }

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

        [ForeignKey("IdDaFatura")]
        public virtual Faturamento Fatura { get; set; }

        #endregion Relacionamentos

        #region Campos de pesquisa

        //public string PesquisaCliente
        //{
        //    get
        //    {
        //        var result = "";

        //        try
        //        {
        //            if (Cliente != null)
        //                result = Cliente.Nome;
        //            else
        //                result = System.Web.HttpContext.Current.Request.Form["pesquisar-clientes"];
        //        }
        //        catch
        //        {
        //        }

        //        return result;
        //    }
        //}

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
        //                result = System.Web.HttpContext.Current.Request.Form["pesquisar-colaboradores"];
        //        }
        //        catch
        //        {
        //        }

        //        return result;
        //    }
        //}

        #endregion Campos de pesquisa

        #region GRID

        public string VencimentoFormatado
        {
            get
            {
                return this.DataDeVencimento.Value.ToShortDateString();
            }
        }

        public string ClienteNome
        {
            get
            {
                var nome = "";

                if (Cliente != null)
                    nome = Cliente.Nome;

                return nome;
            }
        }

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

        #region ReadOnly

        private string[] bancosSuportados
        {
            get
            {
                return new string[] { "001", "033", "341" };
            }
        }

        #endregion ReadOnly

        #region Not Mapped

        [NotMapped]
        public string Redirect { get; set; }

        #endregion Not Mapped

        public void ValidarEmissaoDeBoleto()
        {
            var erros = new List<string>();

            if (!bancosSuportados.Contains(IdDoBanco))
                erros.Add("O banco selecionado não tem permissão para emitir boletos.");

            if (Cliente == null)
                erros.Add("Dados insuficientes, selecione o cliente.");

            if (Cliente != null && string.IsNullOrEmpty(Cliente.Documento))
                erros.Add("Dados insuficientes, o cliente precisa ter um CPF/CNPJ.");

            if (Empresa == null)
                erros.Add("Dados insuficientes, selecione a empresa.");

            if (ContaCorrente == null)
                erros.Add("Dados insuficientes, selecione a conta corrente.");

            if (erros.Count > 0)
                throw new NSGECustomException(string.Join("#", erros));
        }

        public Endereco GetEnderecoFaturamento()
        {
            var temEnderecoNaFatura = Fatura?.ClienteEndereco != null;
            var endereco = temEnderecoNaFatura ?
                                            Fatura.ClienteEndereco :
                                            Cliente.Enderecos.Select(x => x.Endereco).FirstOrDefault(x => x.Faturamento);

            return endereco;
        }
    }
}