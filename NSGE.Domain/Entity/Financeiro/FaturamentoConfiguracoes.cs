using NSGE.CrossCutting.BaseEntity;

namespace NSGE.Domain.Entity.Financeiro
{
    public class FaturamentoConfiguracoes : EntityBase
    {
        public FaturamentoConfiguracoes()
        {
        }

        public FaturamentoConfiguracoes(Faturamento fatura)
        {
            var numeroNotaFiscal = -1;
            int.TryParse(fatura.NumeroDaNotaFiscal, out numeroNotaFiscal);

            this.NumeroDaNotaFiscal = numeroNotaFiscal;
            this.DescricaoDoServico = fatura.DescricaoDoServico;

            this.IntervaloDeDias = fatura.DataDeVencimento.Value.Subtract(fatura.DataDeEmissao).Days;
        }

        public int IntervaloDeDias { get; set; }
        public int NumeroDaNotaFiscal { get; set; }
        public string DescricaoDoServico { get; set; }
    }
}