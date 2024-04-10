namespace NSGE.Infrastructure.SQLBuilder.EventoVeiculo
{
    public class EventoVeiculoSQLContainer
    {
        public string ListarPor()
        {
            return @"SELECT
                        Id, 
                        EventoId, 
                        VeiculoId
                            FROM EventoVeiculo 
                                WHERE (EventoId = @EventoId) OR ((EventoId IS  NULL) AND (@EventoId IS  NULL))";
        }
    }
}