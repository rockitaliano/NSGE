namespace NSGE.Infrastructure.SQLBuilder.ContasAReceber
{
    public class ContasAReceberSQLContainer
    {
        public string GetStatus()
        {
            return @"";
        }

        public string GetAll()
        {
            return @"SELECT
                        CR.Id, 
                        CR.IdDoCentroDeCusto, 
                        CR.IdDoPlanoDeConta, 
                        CR.IdDoStatus, 
                        CR.IdDoCliente, 
                        CR.IdDaEmpresa, 
                        CR.IdDoBanco, 
                        CR.IdDaContaCorrente, 
                        CR.IdDoFuncionario, 
                        CR.IdDaFatura, 
                        CR.IdDoUsuario, 
                        CR.DataDeEmissao, 
                        CR.DataDeVencimento, 
                        CR.DataDoRecebimento, 
                        CR.TipoDeDocumento, 
                        CR.TipoDeDocumentoRecebimento, 
                        CR.NumeroDoDocumento, 
                        CR.NumeroDoDocumentoRecebimento, 
                        CR.NumeroDoBoleto, 
                        CR.NumeroDaParcela, 
                        CR.ValorPrevisto, 
                        CR.ValorPago, 
                        CR.ValorDaMulta, 
                        CR.ValorDeJuros, 
                        CR.ValorDesconto, 
                        CR.ValorNotaFiscal, 
                        CR.OBS, 
                        CR.DataDeCadastro, 
                        CR.DataDeAlteracao
                            FROM ContasAReceber CR
                                WHERE (CR.DataDeVencimento >= @DataInicial) AND (CR.DataDeVencimento <= @DataFinal)
                                    ORDER BY 
                                        CR.DataDeVencimento ASC";
        }

        public string ListarPorTipo()
        {
            return @"SELECT
                        ST.Id, 
                        ST.Descricao, 
                        ST.TipoDoCadastro, 
                        ST.Leitura
                            FROM Status ST
                                WHERE ST.TipoDoCadastro = @tipo
                                    ORDER BY 
                                        ST.Descricao ASC";
        }
    }
}