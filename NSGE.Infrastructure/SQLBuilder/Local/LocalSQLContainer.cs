namespace NSGE.Infrastructure.SQLBuilder.Local
{
    public class LocalSQLContainer
    {
        public string GetAll()
        {
            return @"select Id, Descricao from local Limit 200";
        }

        public string GetByFilter()
        {
            return @"SELECT
                    LC.Id, 
                    LC.Descricao
                        FROM Local AS LC
                            WHERE (LOCATE(LOWER(@Descricao), LOWER(LC.Descricao))) > 0
                                ORDER BY 
                                    LC.Descricao ASC LIMIT 0,10";
        }
        public string Load()
        {
            return @"SELECT
                    Project2.C1, 
                    Project2.Id, 
                    Project2.Descricao, 
                    Project2.C2, 
                    Project2.Id1, 
                    Project2.EnderecoId, 
                    Project2.LocalId, 
                    Project2.Id2, 
                    Project2.CEP, 
                    Project2.Logradouro, 
                    Project2.Numero, 
                    Project2.Complemento, 
                    Project2.Bairro, 
                    Project2.Cidade, 
                    Project2.UF, 
                    Project2.Principal, 
                    Project2.Registro, 
                    Project2.Cobranca, 
                    Project2.Entrega, 
                    Project2.Faturamento, 
                    Project2.Evento
                    FROM (SELECT
                    Limit1.Id, 
                    Limit1.Descricao, 
                    Limit1.C1, 
                    Join1.Id AS Id1, 
                    Join1.EnderecoId, 
                    Join1.LocalId, 
                    Join1.ID1 AS Id2, 
                    Join1.CEP, 
                    Join1.Logradouro, 
                    Join1.Numero, 
                    Join1.Complemento, 
                    Join1.Bairro, 
                    Join1.Cidade, 
                    Join1.UF, 
                    Join1.Principal, 
                    Join1.Registro, 
                    Join1.Cobranca, 
                    Join1.Entrega, 
                    Join1.Faturamento, 
                    Join1.Evento, 
                        CASE WHEN (Join1.Id IS  NULL) THEN (NULL)  ELSE (1) END AS C2
                            FROM (SELECT
                                LC.Id, 
                                LC.Descricao, 
                                1 AS C1
                                    FROM Local AS LC
                                        WHERE LC.Id = @Id LIMIT 1) AS Limit1 LEFT OUTER JOIN (SELECT
                    ENL.Id, 
                    ENL.EnderecoId, 
                    ENL.LocalId, 
                    EN.Id AS ID1, 
                    EN.CEP, 
                    EN.Logradouro, 
                    EN.Numero, 
                    EN.Complemento, 
                    EN.Bairro, 
                    EN.Cidade, 
                    EN.UF, 
                    EN.Principal, 
                    EN.Registro, 
                    EN.Cobranca, 
                    EN.Entrega, 
                    EN.Faturamento, 
                    EN.Evento
                        FROM EnderecoLocal AS ENL 
                            LEFT OUTER JOIN Endereco AS EN ON ENL.EnderecoId = EN.Id) AS Join1 ON Limit1.Id = Join1.LocalId) AS Project2
                     ORDER BY 
                    Project2.Id ASC, 
                    Project2.C2 ASC";
        }

        public string GetEnderecos()
        {
            return @" SELECT
                        Enderecos.C1, 
                        Enderecos.Id, 
                        Enderecos.Descricao, 
                        Enderecos.C2, 
                        Enderecos.Id1, 
                        Enderecos.EnderecoId, 
                        Enderecos.LocalId, 
                        Enderecos.Id2, 
                        Enderecos.CEP, 
                        Enderecos.Logradouro, 
                        Enderecos.Numero, 
                        Enderecos.Complemento, 
                        Enderecos.Bairro, 
                        Enderecos.Cidade, 
                        Enderecos.UF, 
                        Enderecos.Principal, 
                        Enderecos.Registro, 
                        Enderecos.Cobranca, 
                        Enderecos.Entrega, 
                        Enderecos.Faturamento, 
                        Enderecos.Evento
                        FROM (SELECT
                        Limit1.Id, 
                        Limit1.Descricao, 
                        Limit1.C1, 
                        Join1.Id AS Id1, 
                        Join1.EnderecoId, 
                        Join1.LocalId, 
                        Join1.ID1 AS Id2, 
                        Join1.CEP, 
                        Join1.Logradouro, 
                        Join1.Numero, 
                        Join1.Complemento, 
                        Join1.Bairro, 
                        Join1.Cidade, 
                        Join1.UF, 
                        Join1.Principal, 
                        Join1.Registro, 
                        Join1.Cobranca, 
                        Join1.Entrega, 
                        Join1.Faturamento, 
                        Join1.Evento, 
                        CASE WHEN (Join1.Id IS  NULL) THEN (NULL)  ELSE (1) END AS C2
                        FROM (SELECT
                        LC.Id, 
                        LC.Descricao, 
                        1 AS C1
                        FROM Local AS LC
                         WHERE LC.Id = @Id LIMIT 1) AS Limit1 LEFT OUTER JOIN (SELECT
                        ENL.Id, 
                        ENL.EnderecoId, 
                        ENL.LocalId, 
                        EN.Id AS ID1, 
                        EN.CEP, 
                        EN.Logradouro, 
                        EN.Numero, 
                        EN.Complemento, 
                        EN.Bairro, 
                        EN.Cidade, 
                        EN.UF, 
                        EN.Principal, 
                        EN.Registro, 
                        EN.Cobranca, 
                        EN.Entrega, 
                        EN.Faturamento, 
                        EN.Evento
                        FROM EnderecoLocal AS ENL LEFT OUTER JOIN Endereco AS EN ON ENL.EnderecoId = EN.Id) AS Join1 ON Limit1.Id = Join1.LocalId) AS Enderecos
                         ORDER BY 
                        Enderecos.Id ASC, 
                        Enderecos.C2 ASC 
                           
        ";
        }

        public string Delete()
        {
            return @"SELECT
                    LC.Id, 
                    LC.Descricao
                        FROM Local AS LC
                            WHERE LC.Id = @Id LIMIT 2";
        }

        public string Insert()
        {
            return @"INSERT INTO Endereco(
                        Id, 
                        CEP, 
                        Logradouro, 
                        Numero, 
                        Complemento, 
                        Bairro, 
                        Cidade, 
                        UF, 
                        Principal, 
                        Registro, 
                        Cobranca, 
                        Entrega, 
                        Faturamento, 
                            Evento) 
                                VALUES (@Id, @Cep, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Uf, @Principal, @Registro, @Cobranca, @Entrega, @Faturamento, @Evento)";
        }

        public string ExisteLocal()
        {
            return @"SELECT
                        Id, 
                        Descricao
                            FROM Local
                                WHERE ((LOWER(Descricao)) = (LOWER(@Descricao))) OR ((LOWER(Descricao) IS  NULL) AND (LOWER(@Descricao) IS  NULL))";
        }

        public string GetEnderecosByParameter()
        {
            return @"";
        }

        public string RecuperarHospedagens()
        {
            return @"SELECT
                        PRJ.C1, 
                        PRJ.Id, 
                        PRJ.EventoId, 
                        PRJ.LocalId, 
                        PRJ.EnderecoId, 
                        PRJ.Id1, 
                        PRJ.Descricao, 
                        PRJ.C2, 
                        PRJ.Id2, 
                        PRJ.EnderecoId1, 
                        PRJ.LocalId1, 
                        PRJ.Id3, 
                        PRJ.CEP, 
                        PRJ.Logradouro, 
                        PRJ.Numero, 
                        PRJ.Complemento, 
                        PRJ.Bairro, 
                        PRJ.Cidade, 
                        PRJ.UF, 
                        PRJ.Principal, 
                        PRJ.Registro, 
                        PRJ.Cobranca, 
                        PRJ.Entrega, 
                        PRJ.Faturamento, 
                        PRJ.Evento
                            FROM (SELECT
                                LCE.Id, 
                                LCE.EventoId, 
                                LCE.LocalId, 
                                LCE.EnderecoId, 
                                LC.Id AS Id1, 
                                LC.Descricao, 
                                    1 AS C1, 
                            Filter1.Id AS Id2, 
                            Filter1.EnderecoId AS EnderecoId1, 
                            Filter1.LocalId AS LocalId1, 
                            Filter1.ID1 AS Id3, 
                            Filter1.CEP, 
                            Filter1.Logradouro, 
                            Filter1.Numero, 
                            Filter1.Complemento, 
                            Filter1.Bairro, 
                            Filter1.Cidade, 
                            Filter1.UF, 
                            Filter1.Principal, 
                            Filter1.Registro, 
                            Filter1.Cobranca, 
                            Filter1.Entrega, 
                            Filter1.Faturamento, 
                            Filter1.Evento, 
                                CASE WHEN (Filter1.Id IS  NULL) THEN (NULL)  ELSE (1) END AS C2
                                    FROM LocalEvento AS LCE LEFT OUTER JOIN Local AS LC ON LCE.LocalId = LC.Id LEFT OUTER JOIN (SELECT
                                        EL.Id, 
                                        EL.EnderecoId, 
                                        EL.LocalId, 
                                        EN.Id AS ID1, 
                                        EN.CEP, 
                                        EN.Logradouro, 
                                        EN.Numero, 
                                        EN.Complemento, 
                                        EN.Bairro, 
                                        EN.Cidade, 
                                        EN.UF, 
                                        EN.Principal, 
                                        EN.Registro, 
                                        EN.Cobranca, 
                                        EN.Entrega, 
                                        EN.Faturamento, 
                                        EN.Evento
                                            FROM EnderecoLocal AS EL LEFT OUTER JOIN Endereco AS EN ON EL.EnderecoId = EN.Id
                                                WHERE EL.LocalId IS NOT NULL) AS Filter1 ON LCE.LocalId = Filter1.LocalId
                                                    WHERE (LCE.EventoId = @EventoId) OR ((LCE.EventoId IS  NULL) AND (@EventoId IS  NULL))) AS PRJ
                                                         ORDER BY 
                                                            PRJ.Id ASC, 
                                                            PRJ.Id1 ASC, 
                                                            PRJ.C2 ASC";
        }
    }
}