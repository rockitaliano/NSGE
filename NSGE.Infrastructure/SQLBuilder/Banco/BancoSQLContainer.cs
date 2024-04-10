namespace NSGE.Infrastructure.SQLBuilder.Banco
{
    public class BancoSQLContainer
    {
        public string GetBancos()
        {
            return @"Select Id, Descricao FROM Banco ORDER BY Id ASC";
        }

        public string PesquisarBanco()
        {
            return @"SELECT
                        Id, 
                        Descricao
                            FROM Banco WHERE 1 = 1 ";
        }
    }
}