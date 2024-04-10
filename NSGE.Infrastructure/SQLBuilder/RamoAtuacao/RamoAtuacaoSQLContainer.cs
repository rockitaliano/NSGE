namespace NSGE.Infrastructure.SQLBuilder.RamoAtuacao
{
    public class RamoAtuacaoSQLContainer
    {
        public string Filtrar()
        {
            return @"SELECT
                Id,
                Nome
            FROM RamoAtuacao";
        }
    }
}