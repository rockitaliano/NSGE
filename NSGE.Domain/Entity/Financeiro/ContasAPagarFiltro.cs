using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using System.Text;

namespace NSGE.Domain.Entity.Financeiro
{
    public class ContasAPagarFiltro
    {
        public ContasAPagarFiltro()
        {
            this.PeriodoTipo = "V";
            this.DataInicial = DateTime.Now.Date;
            this.DataFinal = DateTime.Now.AddMonths(1).Date;
        }

        public string PeriodoTipo { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string IdDoStatus { get; set; }
        public string IdDaEmpresa { get; set; }
        public string IdDoCentroDeCusto { get; set; }
        public string IdDoPlanoDeConta { get; set; }

        public string Pessoa { get; set; }
        public string Banco { get; set; }
        public string Documento { get; set; }

        public StatusPagamento? StatusPagamento { get; set; }

        public Empresa Empresa { get; set; }
        public Status Status { get; set; }
        public PlanoDeContas PlanoDeConta { get; set; }
        public CentroDeCusto CentroDeCusto { get; set; }

        public bool HasValues()
        {
            return !string.IsNullOrEmpty(PeriodoTipo) ||
                DataInicial.HasValue ||
                DataFinal.HasValue ||
                !string.IsNullOrEmpty(IdDoStatus) ||
                !string.IsNullOrEmpty(IdDaEmpresa) ||
                !string.IsNullOrEmpty(IdDoPlanoDeConta) ||
                !string.IsNullOrEmpty(IdDoCentroDeCusto) ||
                !string.IsNullOrEmpty(Pessoa) ||
                !string.IsNullOrEmpty(Banco) ||
                !string.IsNullOrEmpty(Documento) ||
                !StatusPagamento.HasValue;
        }

        /// <summary>
        /// REPORT
        /// Monta filtro sql para view_contasareceber
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<string, Dictionary<string, object>> MontarWhereSql()
        {
            var sql = "";
            var where = new List<string>();
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(this.Banco))
            {
                where.Add("IdDoBanco like @banco or NomeBanco like @banco");
                parameters.Add("@banco", string.Format("%{0}%", this.Banco));
            }

            if (!string.IsNullOrEmpty(this.PeriodoTipo) && this.DataInicial.HasValue && this.DataFinal.HasValue)
            {
                var datafinal = this.DataFinal.Value.Date.AddDays(1).AddSeconds(-1);
                var condicao = "{0} >= @dataInicial and {0} <= @dataFinal";
                switch (this.PeriodoTipo)
                {
                    case "E": //emissão
                        condicao = string.Format(condicao, "Emissao");
                        break;

                    case "V": //vencimento
                        condicao = string.Format(condicao, "Vencimento");
                        break;
                }

                where.Add(condicao);
                parameters.Add("@dataInicial", this.DataInicial);
                parameters.Add("@dataFinal", datafinal);
            }

            if (!string.IsNullOrEmpty(this.Documento))
            {
                where.Add("NoDocumento like @documento");
                parameters.Add("@documento", string.Format("%{0}%", this.Documento));
            }

            if (!string.IsNullOrEmpty(this.Pessoa))
            {
                where.Add("NomedoClienteRazaoSocial like @pessoa");
                parameters.Add("@pessoa", string.Format("%{0}%", this.Pessoa));
            }

            if (!string.IsNullOrEmpty(this.IdDaEmpresa))
            {
                where.Add("IdEmpresa = @idEmpresa");
                parameters.Add("@idEmpresa", this.IdDaEmpresa);
            }

            if (!string.IsNullOrEmpty(this.IdDoStatus))
            {
                where.Add("IdDoStatus = @idDoStatus");
                parameters.Add("@idDoStatus", this.IdDoStatus);
            }

            if (!string.IsNullOrEmpty(this.IdDoPlanoDeConta))
            {
                where.Add("IdDoPlanoDeConta = @idDoPlanoDeConta");
                parameters.Add("@idDoPlanoDeConta", this.IdDoPlanoDeConta);
            }

            if (!string.IsNullOrEmpty(this.IdDoCentroDeCusto))
            {
                where.Add("IdDoCentroDeCusto = @idDoCentroDeCusto");
                parameters.Add("@idDoCentroDeCusto", this.IdDoCentroDeCusto);
            }

            if (this.StatusPagamento.HasValue)
            {
                if (StatusPagamento == CrosCutting.Enum.StatusPagamento.EmAbertoEVencido)
                {
                    where.Add("(StatusPagamento = @aberto OR StatusPagamento = @vencido)");
                    parameters.Add("@aberto", CrosCutting.Enum.StatusPagamento.EmAberto.GetEnumValue());
                    parameters.Add("@vencido", CrosCutting.Enum.StatusPagamento.Vencido.GetEnumValue());
                }
                else
                {
                    where.Add("StatusPagamento = @statusPagamento");
                    parameters.Add("@statusPagamento", this.StatusPagamento.Value.GetEnumValue());
                }
            }

            if (where.Count > 0)
            {
                sql = " where ";
                sql += string.Join(" and ", where);
            }

            return new KeyValuePair<string, Dictionary<string, object>>(sql, parameters);
        }

        public string MontarDescricaoDosFiltrosSelecionados()
        {
            //Só Contas Recebidas, todas as Empresas, todos os Recebimentos, todas as Contas do plano, todas os C.Custo

            var filtros = new StringBuilder();

            filtros.Append("Filtros: ");
            filtros.Append(Status == null ? "Todos os status, " : string.Format("Só status {0}, ", Status.Descricao));
            filtros.Append(Empresa == null ? "todas as empresas, " : string.Format("só empresa {0}, ", Empresa.RazaoSocial));
            filtros.Append(string.IsNullOrEmpty(Pessoa) ? "todos os fornecedores/funcionários, " : string.Format("só fornecedor/funcionário {0}, ", Pessoa));
            filtros.Append(PlanoDeConta == null ? "todos os planos de contas, " : string.Format("só plano de conta {0}, ", PlanoDeConta.NomeDaConta));
            filtros.Append(CentroDeCusto == null ? "todos os centros de custos, " : string.Format("só centro de custo {0}, ", CentroDeCusto.Descricao));
            filtros.Append(!StatusPagamento.HasValue ? "todas as contas, " : string.Format("só contas {0}, ", StatusPagamento.GetEnumValue().ToLower()));
            filtros.Append(string.IsNullOrEmpty(Banco) ? "todos os bancos, " : string.Format("só banco {0}, ", Banco));
            filtros.Append(string.IsNullOrEmpty(Documento) ? "todos os documentos " : string.Format("só documento {0} ", Documento));

            filtros.AppendFormat("em ordem de {0}", PeriodoTipo == "E" ? "emissão" : "vencimento");

            return filtros.ToString();
        }

        public string MontarDescricaoDoPeriodoSelecionado()
        {
            var periodo = "Período não selecionado";

            if (DataInicial.HasValue && DataFinal.HasValue)
                periodo = string.Format("Período de {0:dd/MM/yyyy} a {1:dd/MM/yyyy}", DataInicial, DataFinal);

            return periodo;
        }
    }
}