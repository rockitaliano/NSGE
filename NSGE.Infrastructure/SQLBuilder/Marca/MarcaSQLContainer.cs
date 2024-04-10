namespace NSGEInfrastructureSQLBuilderMarca
{
    public class MarcaSQLContainer
    {
        public string List()
        {
            return @"SELECT
                    Id, 
                    Descricao
                        FROM Marca
                            ORDER BY 
                                Descricao ASC";
        }

        public string ObterMarca()
        {
            return @"select * from Marca WHERE Id = @Id";
        }
    }
}
