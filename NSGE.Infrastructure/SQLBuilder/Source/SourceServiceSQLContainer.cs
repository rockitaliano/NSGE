namespace NSGE.Infrastructure.SQLBuilder.Source
{
    public class SourceServiceSQLContainer
    {
        public string Filter()
        {
            return @"SELECT
                        Id, 
                        Text, 
                        Tela, 
                        Campo
                            FROM Source
                                WHERE (Tela = @tela) AND (Campo = @campo)
                                    ORDER BY 
                                        Text ASC";
        }
        public string GetSources()
        {
            return @"Select * from Source Order by Tela DESC";
        }

        public string Delete()
        {
            return @"DELTE FROM Source WHERE Id = @Id";
        }

        public string LoadId()
        {
            return @"select * from Source Where Id = @Id";
        }

        public string Update()
        {
            return @"Update Source Set Text = @Text, Tela = @Tela, @campo = @Campo Where Id = @Id; 
                    select * from Source Where Id = @Id;";
            
        }
    }
}