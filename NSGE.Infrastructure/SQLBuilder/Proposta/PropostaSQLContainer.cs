namespace NSGE.Infrastructure.SQLBuilder.Proposta
{
    public class PropostaSQLContainer
    {
        public string GetPropostas()
        {
            return @"select P.NumeroDaProposta, 
                            P.Cliente, 
                            P.Equipamento, 
                            P.Evento, 
                            P.DataDoEvento, 
                            PE.Nome as Vendedor, 
                            S.Descricao 
                    From Proposta P
                        LEFT JOIN pessoa PE on PE.Id = P.IdDoFuncionario
                        LEFT JOIN status S on S.Id = P.IdStatus
                        ORDER BY S.Descricao DESC
                        LIMIT 200";
        }

        public  string GetTipoStatus()
        {
            return @"SELECT 
                        Id, 
                        Descricao, 
                        TipoDoCadastro, 
                        Leitura 
                        FROM Status  
                    WHERE TipoDoCadastro = '{WHERE}' ORDER BY Descricao ASC";
        }

        public  string QueryPropostasParameters()
        {
            return @"SELECT PR.Id, PR.NumeroDaProposta, PR.Evento, PR.Cliente, PR.Data, PR.DataDoEvento, PR.Equipamento, PR.IdDoFuncionario, PR.ValorTotal, PR.UltimaRevisao, 
                        PR.NomeDoContato, PR.DDD, PR.Numero, PR.Email, PR.IdStatus, PE.Nome, PR.Observacao, PR.dataenvioemail, PR.MalaDireta FROM Proposta PR
                        inner join pessoa PE ON PR.IdDoFuncionario = PE.Id
                        WHERE Data >= date_sub(CURDATE(), INTERVAL 120 DAY) ";
        }

        public string QueryPropostasByParameters()
        {
            return @"SELECT PR.Id, PR.NumeroDaProposta, PR.Evento, PR.Cliente, PR.Data, PR.DataDoEvento, PR.Equipamento, PR.IdDoFuncionario, PR.ValorTotal, PR.UltimaRevisao, 
                        PR.NomeDoContato, PR.DDD, PR.Numero, PR.Email, PR.IdStatus, PE.Nome, PR.Observacao, PR.dataenvioemail, PR.MalaDireta FROM Proposta PR
                        inner join pessoa PE ON PR.IdDoFuncionario = PE.Id
                        WHERE 1 = 1";
        }

        public  string ListaVendedores()
        {
           return @"
                SELECT Id, Nome FROM Pessoa WHERE RepresentanteComercial = 1";

        }

        public  string ListarPorTipo()
        {
            return @"SELECT 
                        Id, 
                        Descricao, 
                        TipoDoCadastro, 
                        Leitura 
                        FROM Status  
                    WHERE TipoDoCadastro = '{WHERE}' ORDER BY Descricao ASC";

        }
        public  string GetLastProposal()
        {
            return @"SELECT max(NumeroDaProposta) FROM Proposta";
        }
        public  string AddProposta()
        {
            return @"INSERT INTO PROPOSTA 
                    (Id, NumeroDaProposta, Data, Cliente, IdDoFuncionario, IdStatus, Equipamento, Evento, DataDoEvento, ValorTotal, UltimaRevisao, NomeDoContato,
                        DDD, Numero, Email, Observacao, MalaDireta)
                    VALUES (@Id, @NumeroDaProposta, @Data, @Cliente, @IdDoFuncionario, @IdStatus, @Equipamento, @Evento, @DataDoEvento, @ValorTotal, @UltimaRevisao, @NomeDoContato, 
                        @DDD, @Numero, @Email, @Observacao, @MalaDireta)";
        }

        public string Update()
        {
            return @"UPDATE Proposta 
                        SET NumeroDaProposta= @NumeroProposta, 
                            Evento= @Evento,    
                            Cliente= @Cliente, 
                            Data= @Data, 
                            DataDoEvento= @DataDoEvento, 
                            Equipamento= @Equipamento, 
                            IdDoFuncionario= @IdDoFuncionario, 
                            ValorTotal= @ValorTotal, 
                            UltimaRevisao = @UltimaRevisao, 
                            NomeDoContato= @NomeDoContato, 
                            DDD= @DDD, 
                            Numero= @Numero, 
                            Email= @Email,    
                            MalaDireta= @MalaDireta, 
                            IdStatus= @IdStatus, 
                            Observacao= @Observacao 
                                WHERE Id = @Id";
        }

       
        public string Load()
        {
            return @"SELECT
                        PR.Id, 
                        PR.NumeroDaProposta, 
                        PR.Evento, 
                        PR.Cliente, 
                        PR.Data, 
                        PR.DataDoEvento, 
                        PR.Equipamento, 
                        PR.IdDoFuncionario, 
                        PR.ValorTotal, 
                        PR.UltimaRevisao, 
                        PR.NomeDoContato, 
                        PR.DDD, 
                        PR.Numero, 
                        PR.Email, 
                        PR.MalaDireta, 
                        PR.IdStatus, 
                        PR.Observacao
                            FROM Proposta PR
                                WHERE PR.Id = @Id";
        }

        public string Delete()
        {
            return @"DELETE FROM Proposta WHERE Id = @Id;";
        }
    }
}