namespace NSGE.Infrastructure.SQLBuilder.EventoEquipe
{
    public class EventoEquipeSQLContainer
    {
        public string ListarPorEvento()
        {
            return @"SELECT
                        Id, 
                        EventoId, 
                        PessoaId
                            FROM EventoEquipe 
                                WHERE (EventoId = @EventoId) OR ((EventoId IS  NULL) AND (@EventoId IS  NULL))";
        }
    }
}