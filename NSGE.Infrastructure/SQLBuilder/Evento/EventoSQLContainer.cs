namespace NSGE.Infrastructure.SQLBuilder.Evento
{
    public class EventoSQLContainer
    {
        public string GetEventos()
        {
            return @"SELECT E.Id, E.NumeroDaOS, E.Nome as NomeEvento, P.Nome as NomeCliente , E.InicioDoEvento as DataEvento, en.Logradouro as Endereco FROM evento E
                    LEFT join pessoa P on P.Id = E.IdDoCliente
                    Left join endereco en ON E.EnderecoId = en.Id
                    WHERE 1 = 1
                   ";
        }

        public string GetTodosEventos()
        {
            return @"SELECT E.Id, E.NumeroDaOS, E.Nome as NomeEvento, P.Nome as NomeCliente, E.InicioDoEvento as DataEvento FROM evento E
                    LEFT JOIN pessoa P on P.Id = E.IdDoCliente
                    Limit 200
                   ";
        }

        public string GetOs()
        {
            return @"";
        }

        public string RetonarEvento()
        {
            return @"Select * from evento where Id = @Id";
        }

        public string ListarPorEvento()
        {
            return @"SELECT
                        1 AS C1,
                        EVP.Id,
                        EVP.EventoId,
                        EVP.PessoaId,
                        EVP.Tipo,
                        PE.Discriminator,
                        PE.Id AS Id1,
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
                            FROM EventoPessoa AS EVP LEFT OUTER JOIN Pessoa AS PE ON ((PE.Discriminator = 'PessoaFisica') OR (PE.Discriminator = 'PessoaJuridica')) AND (EVP.PessoaId = PE.Id)
                                WHERE (EVP.EventoId = @EventoId) OR ((EVP.EventoId IS  NULL) AND (@EventoId IS  NULL))";
        }

        public string QueryEventos()
        {
            return @"SELECT
                        Id,
                        NumeroDaOS,
                        Nome,
                        IdDoRepresentanteComercial,
                        IdDoCliente,
                        InicioDoEvento,
                        FimDoEvento,
                        DataDaMontagem,
                        HoraDaMontagem,
                        DataDeSaida,
                        DataDeRetorno,
                        Feedback,
                        Aprovado,
                        LocalId,
                        EnderecoId,
                        IdDoCoordenadorTecnico,
                        Observacoes,
                        IdDoTecnico,
                        DataDaViagem,
                        HoraDaViagem,
                        AlimentacaoCliente,
                        AlimentacaoInfoView,
                        DespesaSublocacao,
                        DespesaHospedagem,
                        DescricaoHospedagem,
                        DespesaImpostos,
                        DespesaBV,
                        DespesaOperacional,
                        DespesaTransporte,
                        DescricaoTransporte,
                        DespesasLocomocaoPessoal,
                        DescricaoLocomocaoPessoal,
                        DespesaMaterialSuprimento,
                        DescricaoMaterialSuprimento,
                        DespesaOutras,
                        DescricaoOutras,
                        UsuarioCadastroId,
                        UsuarioAlteracaoId,
                        DataDeCadastro,
                        DataDeAlteracao
                            FROM Evento";
        }
    }
}