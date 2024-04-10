namespace NSGE.Infrastructure.SQLBuilder.Fabricante
{
    public class FabricanteSQLContainer
    {
        public string GetFabricantes()
        {
            return @"SELECT
                        Id, 
                        Nome
                        FROM Fabricante";
        }

        public string GetName()
        {
            return @"SELECT
                        FB.Id, 
                        FB.Nome
                        FROM Fabricante FB
                            WHERE 1 = 1 ";
        }
    }
}