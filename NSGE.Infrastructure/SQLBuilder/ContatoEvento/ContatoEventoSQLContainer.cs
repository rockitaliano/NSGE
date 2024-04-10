namespace NSGE.Infrastructure.SQLBuilder.ContatoEvento
{
    public class ContatoEventoSQLContainer
    {
        public string RetornaContatoEvento()
        {
            return @" SELECT
                        Id, 
                        ContatoId, 
                        EventoId
                            FROM ContatoEvento 
                                WHERE (EventoId = @EventoId) OR ((EventoId IS  NULL) AND (@EventoId IS  NULL))";
        }
    }
}    