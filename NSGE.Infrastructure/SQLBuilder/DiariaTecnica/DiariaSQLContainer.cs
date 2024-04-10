namespace NSGE.Infrastructure.SQLBuilder.DiariaTecnica
{
    public class DiariaSQLContainer
    {
        public string GetDiarias()
        {
            return @"SELECT 
                        Id, 
                        AgendaId, 
                        EventoId, 
                        TecnicoId, 
                        Tecnico, 
                        Evento, 
                        OS, 
                        ValorDiaria, 
                        ValorAlimentacao, 
                        DiariaPG, 
                        AlimentacaoPG, 
                        Tipo
                            FROM DiariaTecnica Limit 1000";
        }

        public string QueryDiariasParameters()
        {
            return @"SELECT TRIM(BOTH ' ' From Tecnico) AS Tecnico, 
                        Id, 
                        AgendaId, 
                        EventoId, 
                        TecnicoId,                         
                        Evento, 
                        OS, 
                        DataEvento,
                        ValorDiaria, 
                        ValorAlimentacao, 
                        DiariaPG, 
                        AlimentacaoPG, 
                        Tipo
                            FROM DiariaTecnica WHERE 1 = 1";
        }

        public string ListarPorTecnicoEdit()
        {
            return @"SELECT
                        DT.Id, 
                        DT.AgendaId, 
                        DT.EventoId, 
                        DT.TecnicoId, 
                        DT.Tecnico, 
                        DT.Evento, 
                        DT.OS, 
                        DT.DataEvento, 
                        DT.ValorDiaria, 
                        DT.ValorAlimentacao, 
                        DT.DiariaPG, 
                        DT.AlimentacaoPG, 
                        DT.Tipo
                            FROM DiariaTecnica AS DT
                                WHERE (DT.TecnicoId = @TecnicoId) OR ((DT.TecnicoId IS  NULL) AND (@TecnicoId IS  NULL))
                                    ORDER BY 
                                        DT.DataEvento DESC, 
                                        DT.Tecnico ASC";
        }

        public string Update()
        {
            return @"UPDATE TecnicoDia 
                        SET AgendaId=@AgendaId,
                            TecnicoId=@TecnicoId, 
                            ValorDiaria=@ValorDiaria, 
                            ValorAlimentacao=@ValorAlimentacao, 
                            AlimentacaoPG=@Alimentacao, 
                            DiariaPG=@Diaria, 
                            Tipo=@Tipo
                                WHERE Id = @Id";
        }
    }
}