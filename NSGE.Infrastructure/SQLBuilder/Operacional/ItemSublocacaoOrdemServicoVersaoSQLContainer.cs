namespace NSGE.Infrastructure.SQLBuilder.Operacional
{
    public class ItemSublocacaoOrdemServicoVersaoSQLContainer
    {
        public string GetVersao()
        {
            return @"SELECT
                        `GroupBy1`.`A1` AS `C1`
                        FROM (SELECT
                        MAX(`Extent1`.`Versao`) AS `A1`
                            FROM `ItemSublocacaoOrdemServicoVersao` AS `Extent1`
                                WHERE (`Extent1`.`IdOrdemServico` = @IdOrdemServico) OR ((`Extent1`.`IdOrdemServico` IS  NULL) AND (@IdOrdemServico IS  NULL))) AS `GroupBy1`";
        }

        public string GetVersao2()
        {
            return @"SELECT COALESCE(MAX(ISOV.Versao), 0) AS VersaoMaxima
                        FROM ItemSublocacaoOrdemServicoVersao ISOV
                            WHERE ISOV.IdOrdemServico = @IdOrdemServico OR (ISOV.IdOrdemServico IS NULL AND @IdOrdemServico IS NULL)
";
        }
    }
}