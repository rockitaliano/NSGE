using System.Security.Cryptography.X509Certificates;

namespace NSGE.Infrastructure.SQLBuilder.CheckList
{
    public class CheckListSQLContainer
    {
        public string GetCheckList()
        {
            return @"SELECT E.Id, E.Aprovado, E.NumeroDaOS, E.Nome as Nome, P.Nome as NomeCliente, E.InicioDoEvento as DataEvento, E.DataDaMontagem FROM evento E
                    LEFT JOIN pessoa P on P.Id = E.IdDoCliente WHERE E.Aprovado = 0 Order by E.InicioDoEvento DESC LIMIT 200";
        }

        public string GetCheckListByOS()
        {
            return @"SELECT E.Id, E.Aprovado, E.NumeroDaOS, E.Nome as Nome, P.Nome as NomeCliente, E.InicioDoEvento as DataEvento, E.DataDaMontagem FROM evento E
                    LEFT JOIN pessoa P on P.Id = E.IdDoCliente
                    WHERE 1 = 1";
        }
        public string CarregarResponsavel()
        {
            return @"SELECT
                        Limit1.Quantidade, 
                        Limit1.Id, 
                        Limit1.OS, 
                        Limit1.ItemId, 
                        Limit1.ResponsavelId, 
                        Limit1.Id1, 
                        Limit1.Nome, 
                        Limit1.Login, 
                        Limit1.Senha, 
                        Limit1.Email, 
                        Limit1.Status, 
                        Limit1.RecebeEmail, 
                        Limit1.Administrador, 
                        Limit1.Imagem, 
                        Limit1.DataDoCadastro, 
                        Limit1.DataDeAlteracao
                        FROM (SELECT
                        Chk.Id, 
                        Chk.OS, 
                        Chk.ItemId, 
                        Chk.Quantidade, 
                        Chk.ResponsavelId, 
                        Usr.Id AS Id1, 
                        Usr.Nome, 
                        Usr.Login, 
                        Usr.Senha, 
                        Usr.Email, 
                        Usr.Status, 
                        Usr.RecebeEmail, 
                        Usr.Administrador, 
                        Usr.Imagem, 
                        Usr.DataDoCadastro, 
                        Usr.DataDeAlteracao
                    FROM Checklist AS Chk LEFT OUTER JOIN Usuario AS Usr ON Chk.ResponsavelId = Usr.Id
                    WHERE (Chk.OS = @NumeroOs) OR ((Chk.OS IS  NULL) AND (@NumeroOs IS  NULL)) LIMIT 1) AS Limit1";
        }
        public string DeleteArquivo()
        {
            return @"DELETE FROM arquivo WHERE 1=1 AND EventoId = @Id";
        }

        public string DeleteAgendaTecnica()
        {
            return @"DELETE FROM agendatecnica WHERE 1=1 AND EventoId = @Id";
        }
        public string Delete()
        {
            return @"DELETE FROM evento WHERE 1=1 AND Id = @Id";
        }

        public string Exist()
        {
            return @"SELECT
                        CASE WHEN (EXISTS(SELECT
                        1 AS `C1`
                        FROM `Checklist` AS `Extent1`
                         WHERE (`Extent1`.`OS` = @NumeroOs) OR ((`Extent1`.`OS` IS  NULL) AND (@NumeroOs IS  NULL)))) THEN (1)  ELSE (0) END AS `C1`
                        FROM (SELECT
                        1 AS `X`) AS `SingleRowTable1`";
        }

        public string LoadOs()
        {
            return @"SELECT
                        Id, 
                        OS, 
                        Text, 
                        ResponsavelId
                            FROM ChecklistExtra
                        WHERE (OS = @NumeroOs) OR ((OS IS  NULL) AND (@NumeroOs IS  NULL)) LIMIT 2";
        }

        public string ListarPais()
        {
            return @" SELECT
                        Id, 
                        ParentId, 
                        Descricao, 
                        Ordem
                        FROM ItemChecklist
                            WHERE  '#' = ParentId
                            ORDER BY Ordem ASC";
        }

        public string GetQuantity()
        {
            return @"SELECT
                    Quantidade
                        FROM Checklist 
                            WHERE (OS = @NumeroOs OR (OS IS NULL AND @NumeroOs IS  NULL))
                            -- AND (ItemId = @ItemId OR (ItemId IS  NULL AND @ItemId IS  NULL))";
        }

        public string TemFilhos()
        {
            return @"SELECT
                        CASE WHEN (EXISTS(SELECT
                        1 AS C1
                        FROM ItemChecklist AS Extent1
                         WHERE (ParentId = @ParentId) OR ((ParentId IS  NULL) AND (@ParentId IS  NULL)))) THEN (1)  ELSE (0) END AS C1                                         
                        FROM (SELECT
                        1 AS X) AS SingleRowTable1";
        }
        public string ListarFilhos()
        {
            return @"SELECT
                        Id, 
                        ParentId, 
                        Descricao, 
                        Ordem
                        FROM ItemChecklist
                            WHERE (ParentId = @item) OR ((ParentId IS  NULL) AND (@item IS  NULL))
                            ORDER BY 
                                Ordem ASC";
        }

        public string CarregarOS()
        {
            return @"SELECT EV.Id, EV.NumeroDaOS, EV.Nome AS Cliente, PE.Nome AS RepresentanteComercialNome, EV.DataDaMontagem, EV.InicioDoEvento, EV.FimDoEvento, EV.Aprovado FROM evento EV
                        LEFT JOIN pessoa PE ON EV.IdDoRepresentanteComercial = PE.Id
                        LEFT JOIN contatoEvento CE ON PE.id = CE.EventoId
                        LEFT JOIN checklist CK ON EV.IdDoRepresentanteComercial = CK.ResponsavelId
                        WHERE EV.NumeroDaOS = @NumeroOs;";
        }

        public string OperadoresPorOs()
        {
            return @"SELECT
                        Join1.Nome
                        FROM Evento AS Extent1 INNER JOIN (SELECT
                        Extent2.Id, 
                        Extent2.EventoId, 
                        Extent2.PessoaId, 
                        Extent2.Tipo, 
                        Extent3.Id AS ID1, 
                        Extent3.Nome, 
                        Extent3.Documento, 
                        Extent3.DataNascimento, 
                        Extent3.NomeFantasia, 
                        Extent3.TipoPessoa, 
                        Extent3.Cliente, 
                        Extent3.Fornecedor, 
                        Extent3.Funcionario, 
                        Extent3.Sublocacao, 
                        Extent3.Freelancer, 
                        Extent3.Transportadora, 
                        Extent3.Motorista, 
                        Extent3.Tecnico, 
                        Extent3.RepresentanteComercial, 
                        Extent3.Produtor, 
                        Extent3.Almoxarife, 
                        Extent3.ReferenciaBancaria, 
                        Extent3.Email, 
                        Extent3.PaginaWeb, 
                        Extent3.Observacao, 
                        Extent3.UsuarioCadastroId, 
                        Extent3.UsuarioAlteracaoId, 
                        Extent3.DataDeCadastro, 
                        Extent3.DataDeAlteracao, 
                        Extent3.AlimentacaoRJ, 
                        Extent3.AlimentacaoForaRJ, 
                        Extent3.DiariaTecnica, 
                        Extent3.DiariaCoordenador, 
                        Extent3.Imagem, 
                        Extent3.IdStatus, 
                        Extent3.IsEstrangeiro, 
                        Extent3.NomePai, 
                        Extent3.NomeMae, 
                        Extent3.Identidade, 
                        Extent3.Orgao, 
                        Extent3.DataDeEmissao, 
                        Extent3.Sexo, 
                        Extent3.EstadoCivil, 
                        Extent3.Profissao, 
                        Extent3.Naturalidade, 
                        Extent3.InscricaoEstadual, 
                        Extent3.InscricaoMunicipal, 
                        Extent3.Discriminator
                        FROM EventoPessoa AS Extent2 LEFT OUTER JOIN Pessoa AS Extent3 ON ((Extent3.Discriminator = 'PessoaFisica') OR (Extent3.Discriminator = 'PessoaJuridica')) AND (Extent2.PessoaId = Extent3.Id)) AS Join1 ON (Extent1.Id = Join1.EventoId) AND ((Join1.Tipo =  @Tipo) OR ((Join1.Tipo IS  NULL) AND ( @Tipo IS  NULL)))
                         WHERE Extent1.NumeroDaOS = @NumeroOS";
        }
    }
}