namespace NSGE.Infrastructure.SQLBuilder.Operacional
{
    public class ObservacaoOrdemServicoVersaoSQLContainer
    {
        public string GetVersao()
        {
            return @"SELECT COALESCE(MAX(ISOV.Versao), 0) AS VersaoMaxima
                        FROM ObservacaoOrdemServicoVersao ISOV
                            WHERE ISOV.IdOrdemServico = @IdOrdemServico OR (ISOV.IdOrdemServico IS NULL AND @IdOrdemServico IS NULL)";
        }
    }
}