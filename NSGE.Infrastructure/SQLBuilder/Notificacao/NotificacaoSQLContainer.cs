namespace NSGE.Infrastructure.SQLBuilder.Notificacao
{
    public class NotificacaoSQLContainer
    {
        public string Filtrar()
        {
            return @"SELECT
                        Id, 
                        Nome, 
                        Email, 
                        Tipo
                        FROM Notificacao where (@Nome IS NULL OR Nome = @Nome)
                                            AND (@Tipo IS NULL OR Tipo = @Tipo)    
                         ORDER BY 
                            Id ASC";
        }

        public string Insert()
        {
            return @"insert into Notificacao (Id, Nome, Email, Tipo) 
                                            VALUES (@Id, @Nome, @Email, @Tipo); 
                                            SELECT LAST_INSERT_ID();";
                
        }

        public string Update()
        {
            return @"UPDATE Notificacao SET Nome = @Nome, Email = @Email, Tipo = @Tipo WHERE Id = @Id";
        }

        public string Delete()
        {
            return @"delete from Notificacao where Id = @Id";
        }

        public string Load()
        {
            return @"select * from Notificacao Where Id = @Id";
        }
    }
}
