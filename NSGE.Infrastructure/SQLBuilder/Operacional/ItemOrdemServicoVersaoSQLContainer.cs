namespace NSGE.Infrastructure.SQLBuilder.Operacional
{
    public class ItemOrdemServicoVersaoSQLContainer
    {
        public string GetVersao()
        {
            return @"SELECT
                        Id, 
                        IdOrdemServico, 
                        IdEstoque, 
                        Status,
                        Versao,
                        Data,
                        IdUsuario
                            FROM itemordemservicoversao
                                WHERE (IdOrdemServico = @IdOrdemServico) OR ((IdOrdemServico IS  NULL) AND (@IdOrdemServico IS  NULL)) LIMIT 1";
        }
    }
}