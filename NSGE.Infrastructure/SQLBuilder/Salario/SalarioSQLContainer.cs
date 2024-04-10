namespace NSGE.Infrastructure.SQLBuilder.Salario
{
    public class SalarioSQLContainer
    {
        public string GetAll()
        {
            return @"SELECT
                        FU.Id, 
                        FU.FuncionarioId, 
                        FU.Salario,
                        PE.Nome AS FuncionarioNome
                            FROM FuncionarioSalario FU LEFT OUTER JOIN Pessoa PE ON ((PE.Discriminator = 'PessoaFisica') OR (PE.Discriminator = 'PessoaJuridica')) AND (FU.FuncionarioId = PE.Id)
                                ORDER BY 
                                    PE.Nome ASC";
        }

        public string GetById()
        {
            return @"SELECT FS.FuncionarioId, PE.Id, PE.Nome AS FuncionarioNome, FS.Salario 
                        FROM FuncionarioSalario FS
                            LEFT JOIN Pessoa PE ON ((PE.Discriminator = 'PessoaFisica') OR (PE.Discriminator = 'PessoaJuridica')) AND (FS.FuncionarioId = PE.Id)
                            Where FS.Id = @Id";
        }

        public string Insert()
        {
            return @"INSERT INTO FuncionarioSalario(Id, FuncionarioId, Salario) VALUES ( @Id,  @IdFuncionario,  @Valor)";
        }

        public string Update()
        {
            return @"UPDATE FuncionarioSalario 
                    SET Salario=@Salario                         
                    WHERE FuncionarioId = @IdFuncionario";
        }

        public string Delete()
        {
            return @"DELETE FROM FuncionarioSalario WHERE FuncionarioId = @IdFuncionario";
        }
    }
}