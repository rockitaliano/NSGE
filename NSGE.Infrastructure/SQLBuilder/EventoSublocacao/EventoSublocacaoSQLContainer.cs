namespace NSGE.Infrastructure.SQLBuilder.EventoSublocacao
{
    public class EventoSublocacaoSQLContainer
    {
        public string ListarPorEvento()
        {
            return @"SELECT
                        Id, 
                        IdEvento, 
                        IdSublocadora, 
                        Produto, 
                        Quantidade, 
                        Valor, 
                        DataDeCadastro
                            FROM EventoSublocacao 
                                WHERE (IdEvento = @EventoId) OR ((IdEvento IS  NULL) AND (@EventoId IS  NULL))";
        }
    }
}