namespace NSGE.Infrastructure.SQLBuilder.Arquivo
{
    public class ArquivoSQLContainer
    {
        public string ListarPorEvento()
        {
            return @"SELECT
                        Id, 
                        EventoId, 
                        Nome, 
                        Tamanho, 
                        Area, 
                        DataDeCadastro, 
                        DataDeAlteracao, 
                        UsuarioCadastroId, 
                        UsuarioAlteracaoId
                            FROM Arquivo  
                                WHERE (EventoId = @EventoId) OR ((EventoId IS  NULL) AND (@EventoId IS  NULL))";
        }
    }
}