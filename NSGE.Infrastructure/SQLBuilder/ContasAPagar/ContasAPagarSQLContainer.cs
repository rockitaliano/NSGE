namespace NSGE.Infrastructure.SQLBuilder.ContasAPagar
{
    public class ContasAPagarSQLContainer
    {
        public string GetContasAPagar()
        {
            return @"SELECT
                        cp.Id,
                        cp.IdDoCentroDeCusto,
                        cp.IdDoPlanoDeConta,
                        cp.IdDoStatus,
                        cp.IdDaPessoa,
                        p.Nome,
                        cp.IdDaEmpresa,
                        cp.IdDoBanco,
                        cp.IdDaContaCorrente,
                        cp.IdDoFuncionario,
                        cp.IdDaOrdemDeCompra,
                        cp.IdDoUsuario,
                        cp.DataDeEmissao,
                        cp.DataDeVencimento,
                        cp.DataDoPagamento,
                        cp.TipoDeDocumento,
                        cp.TipoDeDocumentoPagamento,
                        cp.NumeroDoDocumento,
                        cp.NumeroDoDocumentoPagamento,
                        cp.NumeroDoBoleto,
                        cp.NumeroDaParcela,
                        cp.ValorPrevisto,
                        cp.ValorPago,
                        cp.ValorDaMulta,
                        cp.ValorDeJuros,
                        cp.ValorDesconto,
                        cp.NumeroNotaFiscal,
                        cp.ValorNotaFiscal,
                        cp.OBS,
                        cp.DataDeCadastro,
                        cp.DataDeAlteracao
                            FROM ContasAPagar cp
                                INNER JOIN pessoa p on cp.IdDaPessoa = p.Id
                                    WHERE DataDeVencimento between @DataInicial AND  @DataFinal
                                        ORDER BY
                                            DataDeVencimento ASC";
        }

        public string GetEmpresa()
        {
            return @"SELECT
                        Id,
                        RazaoSocial,
                        NomeFantasia,
                        Cnpj,
                        DataInscricao,
                        InscricaoEstadual,
                        InscricaoMunicipal,
                        CodigoCNAE,
                        Logo,
                        CEP,
                        Logradouro,
                        Numero,
                        Complemento,
                        Bairro,
                        Cidade,
                        UF,
                        DDD,
                        NumeroTel
                        FROM Empresa
                            ORDER BY
                                RazaoSocial ASC";
        }

        public string GetPlanoContas()
        {
            return @"SELECT
                        Id, 
                        NaturezaDaConta, 
                        Tipo, 
                        ContaSintetica, 
                        CodigoContabil, 
                        Reduzido, 
                        NomeDaConta, 
                        ExibirEmContasAPagar, 
                        ExibirEmContasAReceber
                            FROM PlanoDeContas 
                                WHERE ExibirEmContasAPagar = 1
                                    ORDER BY 
                                        NomeDaConta ASC";
        }

        public string GetCentroCusto()
        {
            return @"SELECT
                        Id, 
                        Descricao, 
                        Codigo, 
                        ExibirEmContasAPagar, 
                        ExibirEmContasAReceber
                            FROM CentroDeCusto 
                                WHERE ExibirEmContasAPagar = 1
                                    ORDER BY 
                                        Descricao ASC";
        }

        public string GetBaixarPorId()
        {
            return @"SELECT
                        CP.Id, 
                        CP.IdDoCentroDeCusto, 
                        CP.IdDoPlanoDeConta, 
                        CP.IdDoStatus, 
                        CP.IdDaPessoa, 
                        CP.IdDaEmpresa, 
                        CP.IdDoBanco, 
                        CP.IdDaContaCorrente, 
                        CP.IdDoFuncionario, 
                        CP.IdDaOrdemDeCompra, 
                        CP.IdDoUsuario, 
                        CP.DataDeEmissao, 
                        CP.DataDeVencimento, 
                        CP.DataDoPagamento, 
                        CP.TipoDeDocumento, 
                        CP.TipoDeDocumentoPagamento, 
                        CP.NumeroDoDocumento, 
                        CP.NumeroDoDocumentoPagamento, 
                        CP.NumeroDoBoleto, 
                        CP.NumeroDaParcela, 
                        CP.ValorPrevisto, 
                        CP.ValorPago, 
                        CP.ValorDaMulta, 
                        CP.ValorDeJuros, 
                        CP.ValorDesconto, 
                        CP.NumeroNotaFiscal, 
                        CP.ValorNotaFiscal, 
                        CP.OBS, 
                        CP.DataDeCadastro, 
                        CP.DataDeAlteracao
                        FROM ContasAPagar CP
                            WHERE CP.Id = @Id 
                                LIMIT 2";
        }

        public string GetStatus()
        {
            return @"SELECT
                        Id, 
                        Descricao, 
                        TipoDoCadastro, 
                        Leitura
                            FROM Status
                                WHERE TipoDoCadastro = @EnumValue
                                    ORDER BY 
                                        Descricao ASC";
        }

    }
}