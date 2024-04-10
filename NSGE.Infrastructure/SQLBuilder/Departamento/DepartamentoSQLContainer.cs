namespace NSGE.Infrastructure.SQLBuilder.Departamento
{
    public class DepartamentoSQLContainer
    {
        public string List()
        {
            return @"SELECT
                        Id,
                        Descricao
                        FROM Departamento";
        }

        public string Create()
        {
            return @"Insert into Departamento (Id, Descricao) VALUES (@Id, @Descricao)";
        }

        public string Delete()
        {
            return @"Delete From Departamento Where Id = @Id";
        }

        public string Update()
        {
            return @"UPDATE Departamento SET Descricao = @Descricao Where Id = @Id";
        }

        public string LoadId()
        {
            return @"SELECT
                        Id, 
                        Descricao
                        FROM Departamento
                         WHERE Id = @Id LIMIT 2";
        }
    }
}