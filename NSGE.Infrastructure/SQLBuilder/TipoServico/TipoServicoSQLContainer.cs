namespace NSGE.Infrastructure.SQLBuilder.TipoServico
{
    public class TipoServicoSQLContainer
    {
        public string Filtrar()
        {
            return @"SELECT
                        TS.Id, 
                        TS.Descricao, 
                        TS.TipoValor, 
                        TS.Valor
                            FROM TipoServico TS
                                ORDER BY 
                                    TS.Descricao ASC";
        }
    }
}