namespace NSGE.Infrastructure.SQLBuilder.Contato
{
    public class ContatoSQLContainer
    {
        public string Update()
        {
            return @"";
        }

        public string Load()
        {
            return @"SELECT
                        Id, 
                        IdDoDepartamento, 
                        Nome, 
                        Funcao, 
                        Email, 
                        MalaDireta, 
                        DataDeCadastro
                            FROM Contato AS 
                                 WHERE Id = @Id LIMIT 2";
        }
    }
}