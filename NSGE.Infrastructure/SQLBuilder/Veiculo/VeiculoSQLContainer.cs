
namespace NSGEInfrastructureSQLBuilderVeiculo
{
    public class VeiculoSQLContainer
    {
        public string Load()
        {
            return @"SELECT
                        Project1.C1, 
                        Project1.Id, 
                        Project1.MarcaId, 
                        Project1.Modelo, 
                        Project1.Descricao, 
                        Project1.Cor, 
                        Project1.AnoDeFabricacao, 
                        Project1.AnoDoModelo, 
                        Project1.Placa, 
                        Project1.Id1, 
                        Project1.Descricao1
                        FROM (SELECT
                        Extent1.Id, 
                        Extent1.MarcaId, 
                        Extent1.Modelo, 
                        Extent1.Descricao, 
                        Extent1.Cor, 
                        Extent1.AnoDeFabricacao, 
                        Extent1.AnoDoModelo, 
                        Extent1.Placa, 
                        Extent2.Id AS Id1, 
                        Extent2.Descricao AS Descricao1, 
                        1 AS C1
                        FROM Veiculo AS Extent1 INNER JOIN Marca AS Extent2 ON Extent1.MarcaId = Extent2.Id) AS Project1
                         ORDER BY 
                        Project1.Id ASC";
        }

        public string Insert()
        {
            return @"INSERT INTO VEICULO (Id, MarcaId, Modelo, Descricao, Cor, AnoDeFabricacao, AnoDoModelo, Placa)
                        VALUES (@Id, @MarcaId, @Modelo, @Descricao, @Cor, @AnoDeFabricacao, @AnoDoModelo, @Placa)";
        }

        public string Exists()
        {
            return @"SELECT Id FROM VEICULO WHERE Id = @Id";
        }

        public string Filter()
        {
            return @"SELECT *
                        FROM Veiculo v
                        inner join marca m on v.MarcaId = m.Id
                            WHERE (@Descricao IS NULL OR m.Descricao LIKE CONCAT('%',  @Descricao, '%')
                              AND (@Modelo IS NULL OR v.Modelo = @Modelo)
                              AND (@Placa IS NULL OR v.Placa = @Placa);";
        }

        public string FilterParameter()
        {
            return @"SELECT
                        P.C1, 
                        P.Id, 
                        P.MarcaId, 
                        P.Modelo, 
                        P.Descricao, 
                        P.Cor, 
                        P.AnoDeFabricacao, 
                        P.AnoDoModelo, 
                        P.Placa, 
                        P.Id1, 
                        P.Descricao1
                        FROM (SELECT
                        V.Id, 
                        V.MarcaId, 
                        V.Modelo, 
                        V.Descricao, 
                        V.Cor, 
                        V.AnoDeFabricacao, 
                        V.AnoDoModelo, 
                        V.Placa, 
                        M.Id AS Id1, 
                        M.Descricao AS Descricao1, 
                        1 AS C1
                            FROM Veiculo AS V 
                            INNER JOIN Marca AS M ON V.MarcaId = M.Id
                                WHERE (@Descricao IS NULL OR LOWER(M.Descricao) LIKE CONCAT('%', LOWER(@Descricao), '%')) 
                                    AND (@Modelo IS NULL OR LOWER(V.Modelo) LIKE CONCAT('%', LOWER(@Modelo), '%'))
                                    AND (@Placa IS NULL OR LOWER(V.Placa) LIKE CONCAT('%', LOWER(@Placa), '%'))) AS P
                                        ORDER BY 
                                            P.Id ASC";
        }
    }
}
