namespace NSGE.Infrastructure.SQLBuilder.PlanoDeContas
{
    public class PlanoDeContasSQLContainer
    {
        public string GetAll()
        {
            return @"SELECT
                        PC.Id,
                        PC.NaturezaDaConta,
                        PC.Tipo,
                        PC.ContaSintetica,
                        PC.CodigoContabil,
                        PC.Reduzido,
                        PC.NomeDaConta,
                        PC.ExibirEmContasAPagar,
                        PC.ExibirEmContasAReceber
                            FROM PlanoDeContas  PC";
        }

        public string Load()
        {
            return @"SELECT
                        PC.Id, 
                        PC.NaturezaDaConta, 
                        PC.Tipo, 
                        PC.ContaSintetica, 
                        PC.CodigoContabil, 
                        PC.Reduzido, 
                        PC.NomeDaConta, 
                        PC.ExibirEmContasAPagar, 
                        PC.ExibirEmContasAReceber
                            FROM PlanoDeContas AS PC
                                WHERE PC.Id = @Id LIMIT 2";
        }

        public string ListarCentroDeCusto()
        {
            return @"SELECT
                    CC.Id, 
                    CC.Descricao, 
                    CC.Codigo, 
                    CC.ExibirEmContasAPagar, 
                    CC.ExibirEmContasAReceber
                        FROM CentroDeCusto CC
                            WHERE CC.ExibirEmContasAReceber = 1
                                ORDER BY 
                                    CC.Descricao ASC";
        }
    }

}