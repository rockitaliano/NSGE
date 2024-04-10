namespace NSGE.Infrastructure.SQLBuilder.Telefone
{
    public class TelefoneSQLContainer
    {
        public string ExcluirPorContato()
        {
            return @"SELECT
                        Id, 
                        DDD, 
                        Numero, 
                        Principal, 
                        IdDoContato
                            FROM Telefone
                                WHERE (IdDoContato = @ContatoId) OR ((IdDoContato IS NULL) AND (@ContatoId IS NULL))";
        }

        public string Insert()
        {
            return @"INSERT INTO Telefone(
                                Id, 
                                DDD, 
                                Numero, 
                                Principal, 
                                IdDoContato) VALUES ( @gp1, @gp2, @gp3, @gp4, @gp5)";
        }
    }
}