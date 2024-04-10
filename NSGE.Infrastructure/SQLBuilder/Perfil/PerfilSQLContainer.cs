namespace NSGE.Infrastructure.SQLBuilder.Perfil
{
    public class PerfilSQLContainer
    {
        public string ListarIgnorandoPerfisDoUsuario()
        {
            return @"SELECT 
                        pfa.PerfilId as Id,
                        pfa.FuncionalidadeId as FuncionalidadeId,
                        pfa.AcessoId as AcessoId,
                        p.Nome AS Nome,
                        p.Descricao AS Descricao,
                        a.Cadastrar,
                        a.Editar,
                        a.Excluir,
                        a.Visualizar,
                        a.Relatorio
                    FROM 
                        PerfilFuncionalidadeAcesso pfa
                    JOIN
                        Funcionalidade p ON pfa.FuncionalidadeId = p.Id
                    JOIN
                        Acesso a ON pfa.AcessoId = a.Id;";
            //return @"SELECT
            //            Id,
            //            Nome,
            //            Descricao
            //                FROM Perfil";
        }

        public string Filtrar()
        {
            return @"SELECT
                        Id, 
                        Nome, 
                        Descricao
                            FROM Perfil                                
                                ORDER BY 
                                    Nome ASC";
        }

        public string ListarPorID()
        {
            return @"SELECT
                        Id, 
                        Nome, 
                        Descricao
                            FROM Perfil
                                WHERE Id NOT  IN ( @Id)";
        }
        public string FiltrarPorNome()
        {
            return @"SELECT
                        Id, 
                        Nome, 
                        Descricao
                            FROM Perfil
                                WHERE Nome Like @Nome
                                ORDER BY 
                                    Nome ASC";
        }
    }
}