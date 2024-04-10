namespace NSGE.Infrastructure.SQLBuilder.EventoProposta
{
    public class EventoPropostaSQLContainer
    {
        public string RetornarEventoProposta()
        {
            return @"SELECT
                        Id, 
                        PropostaId, 
                        EventoId
                            FROM eventoproposta
                                WHERE (EventoId = @EventoId) OR ((EventoId IS  NULL) AND (@EventoId IS  NULL))";
        }
    }
}