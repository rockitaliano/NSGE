namespace NSGE.Infrastructure.SQLBuilder.Almoxarifado
{
    public class AlmoxarifadoSQLContainer
    {
        public string GetRegistros()
        {
            return @"SELECT
                        Id,
                        ServicoAlmoxarifeId,
                        TipoServicoId,
                        Data,
                        DataFim,
                        HoraInicio,
                        HoraFim,
                        ValorServico,
                        ServicoPago,
                        ValorAlimentacao,
                        AlimentacaoPago
                            FROM ServicoAlmoxarifeRegistro";
        }

        public string GetServicos()
        {
            return @"SELECT
                        Id, 
                        PessoaId, 
                        EventoId, 
                        Descricao
                            FROM ServicoAlmoxarife  ";
        }

        public string GetPessoas() 
        {
            return @"SELECT
                        Discriminator, 
                        Id, 
                        Nome, 
                        Documento, 
                        DataNascimento, 
                        NomeFantasia, 
                        TipoPessoa, 
                        Cliente, 
                        Fornecedor, 
                        Funcionario, 
                        Sublocacao, 
                        Freelancer, 
                        Transportadora, 
                        Motorista, 
                        Tecnico, 
                        RepresentanteComercial, 
                        Produtor, 
                        Almoxarife, 
                        ReferenciaBancaria, 
                        Email, 
                        PaginaWeb, 
                        Observacao, 
                        UsuarioCadastroId, 
                        UsuarioAlteracaoId, 
                        DataDeCadastro, 
                        DataDeAlteracao, 
                        AlimentacaoRJ, 
                        AlimentacaoForaRJ, 
                        DiariaTecnica, 
                        DiariaCoordenador, 
                        Imagem, 
                        IdStatus, 
                        IsEstrangeiro, 
                        NomePai, 
                        NomeMae, 
                        Identidade, 
                        Orgao, 
                        DataDeEmissao, 
                        Sexo, 
                        EstadoCivil, 
                        Profissao, 
                        Naturalidade, 
                        InscricaoEstadual, 
                        InscricaoMunicipal
                            FROM Pessoa 
                                WHERE (Discriminator = 'PessoaFisica') OR (Discriminator = 'PessoaJuridica')";
        }

        public string GetPessoa()
        {
            return @"SELECT
                        `Project1`.`C1`, 
                        `Project1`.`Id`, 
                        `Project1`.`Name`
                        FROM (SELECT
                        `Extent1`.`Id`, 
                        `Extent1`.`Nome`, 
                        `Extent1`.`NomeFantasia`, 
                        1 AS `C1`, 
                            CASE WHEN (NOT ((`Extent1`.`NomeFantasia` IS  NULL) OR ((LENGTH(`Extent1`.`NomeFantasia`)) = 0))) THEN (CONCAT(CONCAT(CONCAT(CASE WHEN (`Extent1`.`NomeFantasia` IS  NULL) THEN ('')  ELSE (`Extent1`.`NomeFantasia`) END, ' ('), `Extent1`.`Nome`), ')'))  ELSE (`Extent1`.`Nome`) END AS `Name`
                                FROM `Pessoa` AS `Extent1`
                                    WHERE ((`Extent1`.`Discriminator` = 'PessoaFisica') OR (`Extent1`.`Discriminator` = 'PessoaJuridica')) AND ((1 = `Extent1`.`Almoxarife`) OR (1 = `Extent1`.`Motorista`))) AS `Project1`
                                ORDER BY 
                                    `Project1`.`Nome` ASC, 
                                    `Project1`.`NomeFantasia` ASC";
        }

        public string GetServicoAlmoxarifeRegistro()
        {
            return @"SELECT
                        pessoa.Id AS PessoaId,
                        pessoa.Nome AS PessoaNome,
                        COALESCE(SUM(registro.ValorAlimentacao + registro.ValorServico), 0) AS Total,
                        @dataInicio AS DataInicial,
                        @dataFim AS DataFinal,
                        CASE
                            WHEN pessoa.Motorista THEN 'Motorista'
                            WHEN pessoa.Almoxarife THEN 'Almoxarife'
                            WHEN pessoa.Tecnico THEN 'Tecnico'
                            WHEN pessoa.Freelancer THEN 'Freelancer'
                            WHEN pessoa.Funcionario THEN 'Funcionario'
                            WHEN pessoa.Cliente THEN 'Cliente'
                            WHEN pessoa.Fornecedor THEN 'Fornecedor'
                            WHEN pessoa.Produtor THEN 'Produtor'
                            WHEN pessoa.RepresentanteComercial THEN 'Representante Comercial'
                            WHEN pessoa.Transportadora THEN 'Transportadora'
                            ELSE ''
                        END AS Funcao
                    FROM
                        ServicoAlmoxarifeRegistro registro
                    JOIN
                        ServicoAlmoxarife servico ON registro.ServicoAlmoxarifeId = servico.Id
                    JOIN
                        pessoa pessoa ON servico.PessoaId = pessoa.Id
                    WHERE
                        (COALESCE(@eventoId, '') = '' OR servico.EventoId = @eventoId)
                        AND (COALESCE(@pessoaId, '') = '' OR servico.PessoaId = @pessoaId)
                        AND (NOT COALESCE(@dataInicio, 0) > 0 OR registro.Data >= @dataInicio)
                        AND (NOT COALESCE(@dataFim, 0) > 0 OR registro.Data <= @dataFim)
                    GROUP BY
                        pessoa.Id,
                        pessoa.Nome,
                        pessoa.Cliente, pessoa.Fornecedor, pessoa.Freelancer, pessoa.Funcionario,
                        pessoa.Motorista, pessoa.Almoxarife, pessoa.Produtor, pessoa.RepresentanteComercial,
                        pessoa.Tecnico, pessoa.Transportadora
                    ORDER BY
                        pessoa.Nome;";
        }

        public string GetNome()
        {
            return @"SELECT
                    Limit1.Nome
                    FROM (SELECT
                    Extent1.Nome
                        FROM Pessoa AS Extent1
                            WHERE ((Extent1.Discriminator = 'PessoaFisica') OR (Extent1.Discriminator = 'PessoaJuridica')) AND (Extent1.Id = @PessoaId) LIMIT 1) AS Limit1";
        }

        public string GetTipoServico()
        {
            return @"SELECT
                        Id, 
                        Descricao, 
                        TipoValor, 
                        Valor
                            FROM TipoServico";
        }

        public string GetEventos()
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
                            FROM Evento ";
        }

        public string Load()
        {
            return @"SELECT
                        Id, 
                        ServicoAlmoxarifeId, 
                        TipoServicoId, 
                        Data, 
                        DataFim, 
                        HoraInicio, 
                        HoraFim, 
                        ValorServico, 
                        ServicoPago, 
                        ValorAlimentacao, 
                        AlimentacaoPago
                            FROM ServicoAlmoxarifeRegistro
                                WHERE Id = @Id LIMIT 2";
        }

        public string DropDown()
        {
            return @"SELECT
                        Project1.C1, 
                        Project1.Id, 
                        Project1.Descricao
                        FROM (SELECT
                        Extent1.Id, 
                        Extent1.Descricao, 
                        1 AS C1
                            FROM TipoServico AS Extent1) AS Project1
                                ORDER BY 
                                    Project1.Descricao ASC";
        }

        public string Update()
        {
            return @"UPDATE ServicoAlmoxarifeRegistro SET 
                        ServicoAlmoxarifeId=@ServicoAlmoxarifeId, 
                        TipoServicoId=@TipoServicoId, 
                        Data=@Data, 
                        DataFim=@DataFim, 
                        HoraInicio=@HoraInicio, 
                        HoraFim=@HoraFim, 
                        ValorServico=@ValorServico, 
                        ServicoPago=@ServicoPago, 
                        ValorAlimentacao=@ValorAlimentacao, 
                        AlimentacaoPago=@AlimentacaoPago 
                            WHERE Id = @Id";
        }
    }
}