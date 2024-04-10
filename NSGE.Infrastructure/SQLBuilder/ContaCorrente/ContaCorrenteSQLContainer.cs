namespace NSGE.Infrastructure.SQLBuilder.ContaCorrente
{
    public class ContaCorrenteSQLContainer
    {
        public string PesquisarBancosPorEmpresa()
        {
            return @"SELECT
                        Project2.Id, 
                        Project2.Descricao
                        FROM (SELECT
                        Distinct1.Id, 
                        Distinct1.Descricao
                        FROM (SELECT DISTINCT 
                        BC.Id, 
                        BC.Descricao
                            FROM ContaCorrente AS CC INNER JOIN Banco BC ON CC.IdDoBanco = BC.Id
                                WHERE CC.IdDaEmpresa = @IdDaEmpresa) AS Distinct1) AS Project2
                                    ORDER BY 
                                        Project2.Id ASC";
        }

        public string PesquisarPorEmpresaEBanco()
        {
            return @"SELECT
                        CC.Id, 
                        CC.IdDoBanco, 
                        CC.IdDaEmpresa, 
                        CC.Agencia, 
                        CC.NumeroDaConta, 
                        CC.Variacao, 
                        CC.CodigoCedente, 
                        CC.TipoDocumentoBoleto, 
                        CC.CarteiraCadastrada, 
                        CC.PercentualDeMulta, 
                        CC.PercentualDeJuros, 
                        CC.ValorDeJuros, 
                        CC.NumeroDeDiasDeJuros, 
                        CC.MensagemDoBoleto, 
                        CC.NumeroDoInicioDoNossoNumero, 
                        CC.NumeroDoFinalDoNossoNumero, 
                        CC.NumeroAtualDoNossoNumero                        
                            FROM ContaCorrente CC                                
                                    WHERE (CC.IdDaEmpresa = @IdDaEmpresa) AND (CC.IdDoBanco = @IdDoBanco)
                                        ORDER BY 
                                            CC.Agencia ASC";
        }

        public string GetContasCorrente()
        {
            return @"SELECT
                        CC.Id, 
                        CC.IdDoBanco, 
                        CC.IdDaEmpresa, 
                        CC.Agencia, 
                        CC.NumeroDaConta, 
                        CC.Variacao, 
                        CC.CodigoCedente, 
                        CC.TipoDocumentoBoleto, 
                        CC.CarteiraCadastrada, 
                        CC.PercentualDeMulta, 
                        CC.PercentualDeJuros, 
                        CC.ValorDeJuros, 
                        CC.NumeroDeDiasDeJuros, 
                        CC.MensagemDoBoleto, 
                        CC.NumeroDoInicioDoNossoNumero, 
                        CC.NumeroDoFinalDoNossoNumero, 
                        CC.NumeroAtualDoNossoNumero,
                        EM.RazaoSocial AS Empresa,
                        BC.Descricao AS NomeBanco
                            FROM ContaCorrente CC
                                INNER JOIN empresa EM ON CC.IdDaEmpresa = EM.Id
                                    INNER JOIN banco BC ON CC.IdDoBanco = BC.Id
                                        ORDER BY 
                                            CC.IdDoBanco ASC, 
                                                CC.Agencia ASC, 
                                                    CC.NumeroDaConta ASC";
        }
    }
}