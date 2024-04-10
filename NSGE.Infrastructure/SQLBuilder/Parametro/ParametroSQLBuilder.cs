namespace NSGE.Infrastructure.SQLBuilder.Parametro
{
    public class ParametroSQLBuilder
    {
        public string Filter()
        {
            return @"SELECT
                        `Extent1`.`Id`,
                        `Extent1`.`Key`,
                        `Extent1`.`Value`,
                        `Extent1`.`Descricao`
                        FROM `Parametro` AS `Extent1`
                         WHERE (`Extent1`.`Key` = @Key) OR ((`Extent1`.`Key` IS  NULL) AND (@Key IS  NULL)) LIMIT 1";
        }
    }
}