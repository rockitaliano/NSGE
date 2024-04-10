namespace NSGE.Infrastructure.SQLBuilder.Agenda
{
    public class AgendaSQLContainer
    {
        public string GetAgendaTecnica()
        {
            return @"SELECT
                        Id, 
                        EventoId, 
                        Data, 
                        BgColor, 
                        FontColor, 
                        Exibir
                        FROM AgendaTecnica
                    WHERE Exibir = 1 AND Data >= @DataInicial AND Data <= @DataFinal";
        }

        public string RetornaAgenda()
        {
            return @"Select * from agendatecnica 
                        where EventoId = @EventoId
                            Order By Data";
        }

        public string RetornarEvento()
        {
            return @"SELECT * FROM EVENTO WHERE Id = @Id";
        }
    }
}