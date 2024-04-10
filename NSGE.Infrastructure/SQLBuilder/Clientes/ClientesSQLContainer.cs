namespace NSGE.Infrastructure.SQLBuilder.Pessoa
{
    public class ClientesSQLContainer
    {
        public string GetClientes()
        {
            return @"SELECT Distinct P.Id, P.NomeFantasia, P.Nome, P.Documento, concat(P.Nome, ' : ', '(', T.DDD, ')', T.Numero) AS ContatosConcat, S.Id as IdStatus, S.Descricao as Status FROM Pessoa P
                                INNER JOIN status S ON P.IdStatus = S.Id
                                INNER JOIN (SELECT CP.Id, CP.PessoaId AS ID1 FROM ContatoPessoa CP 
	                            LEFT OUTER JOIN Contato C ON CP.ContatoId = C.Id
                                LEFT OUTER JOIN Telefone T ON T.IdDoContato = CP.ContatoId) AS Teste ON P.Id = Teste.ID1
                                INNER JOIN ContatoPessoa CoP ON CoP.PessoaId = P.Id
                                INNER JOIN Contato C ON C.Id = CoP.ContatoId
                                INNER JOIN Telefone T ON T.IdDoContato = CoP.ContatoId                               
                                ORDER BY P.Nome, P.NomeFantasia ASC 
                    limit 1000";

            //return @"SELECT P.NomeFantasia, C.Nome, P.Documento, S.Descricao
            //            FROM pessoa P
            //            LEFT JOIN Status S On S.Id = P.IdStatus
            //            LEFT JOIN Contato C ON C.Id = P.Id
            //            LEFT JOIN departamento D On D.Id = C.Id
            //            WHERE TipoPessoa = 'PF'
            //            ORDER BY P.DataDeCadastro, P.DataDeEmissao DESC
            //            LIMIT 200";
        }

        public string GetPessoasPorId()
        {
            return @"SELECT P.NomeFantasia, C.Nome, P.Documento, S.Descricao
                        FROM pessoa P
                        LEFT JOIN Status S On S.Id = P.IdStatus
                        LEFT JOIN Contato C ON C.Id = P.Id
                        LEFT JOIN departamento D On D.Id = C.Id 
                            WHERE P.Id = {WHERE}
                        ORDER BY P.DataDeCadastro, P.DataDeEmissao DESC
                        LIMIT 200";
        }

        public string Pesquisa()
        {
            return @"SELECT Distinct P.Id, QA.Id AS QualificacaoId, RA.Id AS RamoAtuacaoId, P.NomeFantasia, P.Nome, P.Documento, concat(P.Nome, ' : ', '(', T.DDD, ')', T.Numero) AS ContatosConcat, S.Id as IdStatus, S.Descricao as Status FROM Pessoa P
                                INNER JOIN status S ON P.IdStatus = S.Id
                                INNER JOIN (SELECT CP.Id, CP.PessoaId AS ID1 FROM ContatoPessoa CP 
	                            LEFT OUTER JOIN Contato C ON CP.ContatoId = C.Id
                                LEFT OUTER JOIN Telefone T ON T.IdDoContato = CP.ContatoId) AS Teste ON P.Id = Teste.ID1
                                INNER JOIN ContatoPessoa CoP ON CoP.PessoaId = P.Id
                                INNER JOIN Contato C ON C.Id = CoP.ContatoId
                                INNER JOIN Telefone T ON T.IdDoContato = CoP.ContatoId      
                                Inner join PessoaQualificacao PQ ON P.Id = PQ.PessoaId
                                inner join Qualificacao QA ON PQ.QualificacaoId = QA.Id
                                inner join pessoaramoatuacao PR ON P.Id = PR.PessoaId
                                inner join ramoatuacao RA ON PR.RamoAtuacaoId = RA.Id
                                WHERE 1 = 1 ";
        }

        public string RetornarPessoa()
        {
            return @"Select * From Pessoa Where Id = @Id";
        }

        public string Load()
        {
            return @"SELECT
                        p.*,
                        e.Id,                        
                        e.CEP,
                        e.Logradouro,
                        e.Numero,
                        e.Complemento,
                        e.Bairro,
                        e.Cidade,
                        e.UF,
                        e.Principal,
                        e.Registro,
                        e.Cobranca,
                        e.Entrega,
                        e.Faturamento,
                        e.Evento,
                        c.Nome AS Nome1,
                        c.Funcao,
                        c.Email AS Email1,
                        c.MalaDireta,
                        c.DataDeCadastro AS DataDeCadastro1,                        
                        t.DDD,
                        t.Numero,
                        t.Principal AS PrincipalTelefone,
                        t.IdDoContato
                            FROM Pessoa p
                                LEFT JOIN EnderecoPessoa ep ON p.Id = ep.PessoaId
                                LEFT JOIN Endereco e ON ep.EnderecoId = e.Id
                                LEFT JOIN ContatoPessoa cp ON p.Id = cp.PessoaId
                                LEFT JOIN Contato c ON cp.ContatoId = c.Id
                                LEFT JOIN Telefone t ON t.IdDoContato = c.Id
                                    WHERE p.Id = @Id;";
        }

        public string Filter()
        {
            return @"SELECT
                        prj.C1, 
                        prj.Id, 
                        prj.C2
                        FROM (SELECT
                        pe.Id, 
                        pe.Nome, 
                        pe.NomeFantasia, 
                        1 AS C1, 
                            CASE WHEN (NOT ((pe.NomeFantasia IS  NULL) OR ((LENGTH(pe.NomeFantasia)) = 0))) THEN (CONCAT(CONCAT(CONCAT(CASE WHEN (pe.NomeFantasia IS  NULL) THEN ('')  ELSE (pe.NomeFantasia) END, ' ('), pe.Nome), ')'))  ELSE (pe.Nome) END AS C2
                                FROM Pessoa AS pe
                                    WHERE ((pe.Discriminator = 'PessoaFisica') OR (pe.Discriminator = 'PessoaJuridica')) AND (1 = pe.Sublocacao)) AS prj
                                        ORDER BY 
                                            prj.Nome ASC, 
                                            prj.NomeFantasia ASC";
        }

        public string Listar()
        {
            return @"SELECT
            p.Id,
            p.Nome,
            p.RepresentanteComercial,
            p.IdStatus,
            p.NomeFantasia
                FROM
                    Pessoa p
                        LEFT JOIN Status s ON p.IdStatus = s.Id
                        LEFT JOIN Endereco e ON p.Id = e.Id
                        LEFT JOIN Contato c ON p.Id = c.Id
                        LEFT JOIN Contato co ON c.Id = co.Id
                        LEFT JOIN Telefone t ON co.Id = t.IdDoContato
                            WHERE p.RepresentanteComercial = 1";
        }


    }
}