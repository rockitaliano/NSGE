namespace NSGE.Infrastructure.SQLBuilder.Faturamento
{
    public class FaturamentoSQLContainer
    {
        public string Filtrar()
        {
            return @"SELECT
                       Extent1.Id, 
                       Extent1.IdDoCliente, 
                       Extent1.IdDoEndereco, 
                       Extent1.IdDoCentroDeCusto, 
                       Extent1.IdDoPlanoDeConta, 
                       Extent1.IdDoBanco, 
                       Extent1.IdDaContaCorrente, 
                       Extent1.IdDoFuncionario, 
                       Extent1.IdDaEmpresa, 
                       Extent1.NumeroDaNotaFiscal, 
                       Extent1.DataDeEmissao, 
                       Extent1.DataDeVencimento, 
                       Extent1.IntervaloDeDias, 
                       Extent1.Parcelas, 
                       Extent1.ValorTotal, 
                       Extent1.TipoDocumento, 
                       Extent1.DescricaoDoServico, 
                       Extent1.DataDeCadastro, 
                       Extent1.DataDeAlteracao, 
                       Extent1.UsuarioCadastroId, 
                       Extent1.UsuarioAlteracaoId, 
                       Extent2.Id AS Id1, 
                       Extent2.Nome, 
                       Extent2.Documento, 
                       Extent2.DataNascimento, 
                       Extent2.NomeFantasia, 
                       Extent2.TipoPessoa, 
                       Extent2.Cliente, 
                       Extent2.Fornecedor, 
                       Extent2.Funcionario, 
                       Extent2.Sublocacao, 
                       Extent2.Freelancer, 
                       Extent2.Transportadora, 
                       Extent2.Motorista, 
                       Extent2.Tecnico, 
                       Extent2.RepresentanteComercial, 
                       Extent2.Produtor, 
                       Extent2.Almoxarife, 
                       Extent2.ReferenciaBancaria, 
                       Extent2.Email, 
                       Extent2.PaginaWeb, 
                       Extent2.Observacao, 
                       Extent2.UsuarioCadastroId AS UsuarioCadastroId1, 
                       Extent2.UsuarioAlteracaoId AS UsuarioAlteracaoId1, 
                       Extent2.DataDeCadastro AS DataDeCadastro1, 
                       Extent2.DataDeAlteracao AS DataDeAlteracao1, 
                       Extent2.AlimentacaoRJ, 
                       Extent2.AlimentacaoForaRJ, 
                       Extent2.DiariaTecnica, 
                       Extent2.DiariaCoordenador, 
                       Extent2.Imagem, 
                       Extent2.IdStatus, 
                       Extent2.IsEstrangeiro, 
                       Extent2.NomePai, 
                       Extent2.NomeMae, 
                       Extent2.Identidade, 
                       Extent2.Orgao, 
                       Extent2.DataDeEmissao AS DataDeEmissao1, 
                       Extent2.Sexo, 
                       Extent2.EstadoCivil, 
                       Extent2.Profissao, 
                       Extent2.Naturalidade, 
                       Extent2.InscricaoEstadual, 
                       Extent2.InscricaoMunicipal, 
                       Extent2.Discriminator
                               FROM Faturamento AS Extent1 
                                      LEFT OUTER JOIN Pessoa AS Extent2 ON ((Extent2.Discriminator = 'PessoaFisica') OR (Extent2.Discriminator = 'PessoaJuridica')) 
                                           AND (Extent1.IdDoCliente = Extent2.Id)
                                                WHERE 1 = 1";
                }

        public string GetPessoa()
        {
            return @"SELECT
                            PE.Discriminator, 
                            PE.Id, 
                            PE.Nome, 
                            PE.Documento, 
                            PE.DataNascimento, 
                            PE.NomeFantasia, 
                            PE.TipoPessoa, 
                            PE.Cliente, 
                            PE.Fornecedor, 
                            PE.Funcionario, 
                            PE.Sublocacao, 
                            PE.Freelancer, 
                            PE.Transportadora, 
                            PE.Motorista, 
                            PE.Tecnico, 
                            PE.RepresentanteComercial, 
                            PE.Produtor, 
                            PE.Almoxarife, 
                            PE.ReferenciaBancaria, 
                            PE.Email, 
                            PE.PaginaWeb, 
                            PE.Observacao, 
                            PE.UsuarioCadastroId, 
                            PE.UsuarioAlteracaoId, 
                            PE.DataDeCadastro, 
                            PE.DataDeAlteracao, 
                            PE.AlimentacaoRJ, 
                            PE.AlimentacaoForaRJ, 
                            PE.DiariaTecnica, 
                            PE.DiariaCoordenador, 
                            PE.Imagem, 
                            PE.IdStatus, 
                            PE.IsEstrangeiro, 
                            PE.NomePai, 
                            PE.NomeMae, 
                            PE.Identidade, 
                            PE.Orgao, 
                            PE.DataDeEmissao, 
                            PE.Sexo, 
                            PE.EstadoCivil, 
                            PE.Profissao, 
                            PE.Naturalidade, 
                            PE.InscricaoEstadual, 
                            PE.InscricaoMunicipal
                                FROM Pessoa AS PE
                                    WHERE (((PE.Discriminator = 'PessoaFisica') OR (PE.Discriminator =  'PessoaJuridica' )) AND (((LOCATE(LOWER(@Dynamic), LOWER(PE.Nome))) > 0) OR (PE.Documento LIKE @Dynamic2 ))) AND (1 = PE.Cliente)
                                        ORDER BY 
                                            PE.Nome ASC";
        }

        public string RetornarFaturamentoEvento()
        {
            return @"SELECT
                    Id, 
                    IdFaturamento, 
                    IdEvento
                        FROM FaturamentoEvento 
                            WHERE (IdEvento = @EventoId) OR ((IdEvento IS  NULL))";
        }
    }
}