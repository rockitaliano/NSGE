namespace NSGE.Infrastructure.SQLBuilder.Security
{
    public class FuncionalidadeSQLContainer
    {
        public string List()
        {
            return @"SELECT
                        Id,
                        Nome,
                        Descricao
                            FROM Funcionalidade
                                WHERE Id NOT  IN ( @gp1,@gp2,@gp3,@gp4,@gp5,@gp6,@gp7,@gp8,@gp9 )
                                 ORDER BY
                                    Nome ASC";
        }

        public string Funcionalidade()
        {
            return @"SELECT
                        Id, 
                        Nome, 
                        Descricao
                            FROM Funcionalidade
                                ORDER BY 
                                    Descricao ASC";
        }
    }
}