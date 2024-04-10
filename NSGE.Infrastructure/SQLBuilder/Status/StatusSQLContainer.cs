namespace NSGE.Infrastructure.SQLBuilder.Status
{
    public class StatusSQLContainer
    {
        public string Load()
        {
            return @"SELECT
                    Id, 
                    Descricao, 
                    TipoDoCadastro, 
                    Leitura
                        FROM Status
                            ORDER BY 
                                Id ASC";
        }

        public string LoadId()
        {
            return @"SELECT
                    Id, 
                    Descricao, 
                    TipoDoCadastro, 
                    Leitura
                        FROM Status
                            WHERE Id = @Id";
        }

        public string Delete()
        {
            return @"DELETE FROM Status WHERE Id= @Id";
        }

        public string Update()
        {
            return @" UPDATE Status
            SET Descricao = @Descricao,
                TipoDoCadastro = @TipoDoCadastro,
                TesteEnum = @TesteEnum,
                Leitura = @Leitura
            WHERE Id = @Id;
            SELECT * FROM Status WHERE Id = @Id;";
        }
    }
}