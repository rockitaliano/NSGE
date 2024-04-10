namespace NSGE.Infrastructure.SQLBuilder.AgendaTecnica
{
    public class AgendaTecnicaSQLContainer
    {
        public string RetornarAgenda()
        {
            return @"SELECT * FROM AGENDATECNICA WHERE EVENTOID = @IdEvento ORDER BY DATA";
        }
    }
}