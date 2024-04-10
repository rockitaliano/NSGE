namespace NSGE.Infrastructure.SQLBuilder.TecnicoDia
{
    public class TecnicoDiaSQLContainer
    {
        public string RetornarTecnico()
        {
            return @"Select * from tecnicodia where AgendaId = @AgendaId";
        }
    }
}