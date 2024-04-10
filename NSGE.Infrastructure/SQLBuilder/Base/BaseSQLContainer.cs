namespace NSGE.Infrastructure.SQLBuilder.Base
{
    public class BaseSQLContainer
    {
        public string Filter()
        {
            return @"SELECT
                    `Extent1`.`Id`,
                    `Extent1`.`Key`,
                    `Extent1`.`Value`
                    FROM `Sistema` AS `Extent1`";
        }
    }
}