namespace NSGE.Infrastructure.SQLBuilder.Listas
{
    public class ListasSQLContainer
    {
        public string GetQualificacao()
        {
            return @"SELECT
                    Id,
                    Nome
                    FROM Qualificacao";
        }

        public string GetRamoAtuacao()
        {
            return @"SELECT
                        Id, 
                        Nome
                            FROM RamoAtuacao";
        }
    }
}