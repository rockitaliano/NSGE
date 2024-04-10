namespace NSGE.Infrastructure.SQLBuilder.ProdutoComposto
{
    public class ProdutoCompostoSQLContainer
    {
        public string GetAllProdutoComposto()
        {
            return @"SELECT * FROM PRODUTOCOMPOSTO LIMIT 0, 500";
        }
    }
}