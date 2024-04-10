namespace NSGE.Infrastructure.SQLBuilder.CentroDeCusto
{
    public class CentroDeCustoSQLContainer
    {
        public string GetCentroDeCusto()
        {
            return @"SELECT
                        Id, 
                        Descricao, 
                        Codigo, 
                        ExibirEmContasAPagar, 
                        ExibirEmContasAReceber
                            FROM CentroDeCusto
                                ORDER BY 
                                    Codigo ASC";
        }

        public string Existe()
        {
            return @"SELECT
                    CASE WHEN (EXISTS(SELECT
                    1 AS C1
                        FROM CentroDeCusto AS Extent1
                            WHERE (Extent1.Codigo = @Codigo) OR (((LOWER(Extent1.Descricao)) = (LOWER(@Descricao))) OR ((LOWER(Extent1.Descricao) IS  NULL) 
                                AND (LOWER(@Descricao) IS  NULL))))) THEN (1)  ELSE (0) END AS C1
                                    FROM (SELECT
                    1 AS X) AS SingleRowTable1";
        }

        public string Insert()
        {
            return @"INSERT INTO CentroDeCusto(
                                    Id, 
                                    Descricao, 
                                    Codigo, 
                                    ExibirEmContasAPagar, 
                                    ExibirEmContasAReceber) VALUES (@gp1, @gp2, 51, 1, 1)";
        }

        public string GetCentroDeCustoById()
        {
            return @"SELECT
                        Extent1.Id, 
                        Extent1.Descricao, 
                        Extent1.Codigo, 
                        Extent1.ExibirEmContasAPagar, 
                        Extent1.ExibirEmContasAReceber
                            FROM CentroDeCusto AS Extent1
                                WHERE Extent1.Id = @Id LIMIT 2";
        }

        public string Update()
        {
            return @"UPDATE CentroDeCusto SET Descricao=@Descricao, 
                                              Codigo=@Codigo, 
                                              ExibirEmContasAPagar=@ExibirContasAPagar, 
                                              ExibirEmContasAReceber=@ExibirContasAReceber 
                                                WHERE Id = @Id";
        }

        public string Delete()
        {
            return @"delete from centrodecusto where Id = @Id";
        }
    }
}