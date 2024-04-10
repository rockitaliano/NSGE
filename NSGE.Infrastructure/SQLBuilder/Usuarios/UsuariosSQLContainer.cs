namespace NSGE.Infrastructure.SQLBuilder.Usuarios
{
    public class UsuariosSQLContainer
    {
        public string GetUsuarios()
        {
            return @"SELECT
                        u.Id,
                        u.Nome,
                        u.Login,
                        u.Senha,
                        u.Email,
                        u.Status,
                        u.RecebeEmail,
                        u.Administrador,
                        u.Imagem,
                        u.DataDoCadastro,
                        u.DataDeAlteracao,
                        p.Id AS PerfilId,
                        p.Nome AS NomePerfil,
                        pf.FuncionalidadeId,
                        pf.AcessoId,
                        --pf.Cadastrar,
                        --pf.Editar,
                        --pf.Excluir,
                        --pf.Visualizar,
                        --pf.Relatorio,
                        f.Nome AS NomeFuncionalidade,
                        f.Descricao AS DescricaoFuncionalidade
                            FROM Usuario u
                                LEFT JOIN UsuarioPerfil up ON u.Id = up.UsuarioId
                                LEFT JOIN Perfil p ON up.PerfilId = p.Id
                                LEFT JOIN PerfilFuncionalidadeAcesso pf ON p.Id = pf.PerfilId
                                LEFT JOIN Funcionalidade f ON pf.FuncionalidadeId = f.Id
                                    WHERE 
                                        LOWER(u.Login) = @usuario OR LOWER(u.Email) = @usuario;";
        }

        public string Load()
        {
            return @"SELECT
                        p.C1,
                        p.Id,
                        p.Nome,
                        p.Login,
                        p.Senha,
                        p.Email,
                        p.Status,
                        p.RecebeEmail,
                        p.Administrador,
                        p.Imagem,
                        p.DataDoCadastro,
                        p.DataDeAlteracao,
                        p.C4 AS C2,
                        p.C2 AS C3,
                        p.Id1,
                        p.UsuarioId,
                        p.PerfilId,
                        p.Id2,
                        p.Nome1,
                        p.Descricao,
                        p.C3 AS C4,
                        p.Id3,
                        p.PerfilId1,
                        p.FuncionalidadeId,
                        p.AcessoId,
                        p.Id4,                        
                        p.Id5,
                        p.Nome2,
                        p.Descricao1
                            FROM (
                                SELECT
                                    u.Id,
                                    u.Nome,
                                    u.Login,
                                    u.Senha,
                                    u.Email,
                                    u.Status,
                                    u.RecebeEmail,
                                    u.Administrador,
                                    u.Imagem,
                                    u.DataDoCadastro,
                                    u.DataDeAlteracao,
                                    1 AS C1,
                                    up.Id AS Id1,
                                    up.UsuarioId,
                                    up.PerfilId,
                                    p.Id AS Id2,
                                    p.Nome AS Nome1,
                                    p.Descricao,
                                    CASE WHEN up.Id IS NULL THEN NULL ELSE 1 END AS C2,
                                    pf.Id AS Id3,
                                    pf.PerfilId AS PerfilId1,
                                    pf.FuncionalidadeId,
                                    pf.AcessoId,
                                    pf.Id AS Id4,
                                    f.Id AS Id5,
                                    f.Nome AS Nome2,
                                    f.Descricao AS Descricao1,
                                    CASE WHEN pf.Id IS NULL THEN NULL ELSE 1 END AS C3,
                                    CASE WHEN pf.Id IS NULL THEN NULL ELSE 1 END AS C4
                                        FROM Usuario u
                                            LEFT JOIN UsuarioPerfil up ON u.Id = up.UsuarioId
                                            LEFT JOIN Perfil p ON up.PerfilId = p.Id
                                            LEFT JOIN PerfilFuncionalidadeAcesso pf ON p.Id = pf.PerfilId
                                            LEFT JOIN Funcionalidade f ON pf.FuncionalidadeId = f.Id
                                            WHERE u.Id = @Id
                                                ) AS p
                                                ORDER BY p.Id ASC, p.C4 ASC, p.Id1 ASC, p.Id2 ASC, p.C3 ASC;
                                            ";
        }

        public string FilterWithRelation()
        {
            return @"SELECT
                        p.C1,
                        p.Id,
                        p.Nome,
                        p.Login,
                        p.Senha,
                        p.Email,
                        p.Status,
                        p.RecebeEmail,
                        p.Administrador,
                        p.Imagem,
                        p.DataDoCadastro,
                        p.DataDeAlteracao,
                        p.C4 AS C2,
                        p.C2 AS C3,
                        p.Id1,
                        p.UsuarioId,
                        p.PerfilId,
                        p.Id2,
                        p.Nome1,
                        p.Descricao,
                        p.C3 AS C4,
                        p.Id3,
                        p.PerfilId1,
                        p.FuncionalidadeId,
                        p.AcessoId,
                        p.Id4,
                        p.Cadastrar,
                        p.Editar,
                        p.Excluir,
                        p.Visualizar,
                        p.Relatorio,
                        p.Id5,
                        p.Nome2,
                        p.Descricao1
                            FROM (
                                SELECT
                                    u.Id,
                                    u.Nome,
                                    u.Login,
                                    u.Senha,
                                    u.Email,
                                    u.Status,
                                    u.RecebeEmail,
                                    u.Administrador,
                                    u.Imagem,
                                    u.DataDoCadastro,
                                    u.DataDeAlteracao,
                                    1 AS C1,
                                    up.Id AS Id1,
                                    up.UsuarioId,
                                    up.PerfilId,
                                    p.Id AS Id2,
                                    p.Nome AS Nome1,
                                    p.Descricao,
                                    CASE WHEN up.Id IS NULL THEN NULL ELSE 1 END AS C2,
                                    pf.Id AS Id3,
                                    pf.PerfilId AS PerfilId1,
                                    pf.FuncionalidadeId,
                                    pf.AcessoId,
                                    pf.Id AS Id4,
                                    pf.Cadastrar,
                                    pf.Editar,
                                    pf.Excluir,
                                    pf.Visualizar,
                                    pf.Relatorio,
                                    f.Id AS Id5,
                                    f.Nome AS Nome2,
                                    f.Descricao AS Descricao1,
                                    CASE WHEN pf.Id IS NULL THEN NULL ELSE 1 END AS C3,
                                    CASE WHEN pf.Id IS NULL THEN NULL ELSE 1 END AS C4
                                        FROM Usuario u
                                            LEFT JOIN UsuarioPerfil up ON u.Id = up.UsuarioId
                                            LEFT JOIN Perfil p ON up.PerfilId = p.Id
                                            LEFT JOIN PerfilFuncionalidadeAcesso pf ON p.Id = pf.PerfilId
                                            LEFT JOIN Funcionalidade f ON pf.FuncionalidadeId = f.Id
                                            WHERE (LOWER(u.Login) = LOWER(@Login) OR LOWER(u.Email) = LOWER(@Login))
                                            AND (u.Login IS NOT NULL OR @Login IS NULL)
                                            AND (u.Email IS NOT NULL OR @Login IS NULL)
                                            LIMIT 1
                                        ) AS p
                                        ORDER BY p.Id ASC, p.C4 ASC, p.Id1 ASC, p.Id2 ASC, p.C3 ASC;
                                    ";
        }

        public string Listar()
        {
            return @"SELECT
                        Id, 
                        Nome, 
                        Login, 
                        Senha, 
                        Email, 
                        Status, 
                        RecebeEmail, 
                        Administrador, 
                        Imagem, 
                        DataDoCadastro, 
                        DataDeAlteracao
                        FROM Usuario
                         ORDER BY 
                        Id ASC";
        }

        public string GetPerfisUsuario()
        {
            return @"
                    SELECT 
                    u.Id AS UsuarioId,
                    u.Nome AS Usuario,
                    u.Login,
                    u.Senha,
                    u.Email,
                    u.Status,
                    u.RecebeEmail,
                    u.Administrador,
                    u.Imagem,
                    u.DataDoCadastro,
                    up.PerfilId,
                    p.Id,
                    p.Nome,
                    p.Descricao
                FROM 
                    Usuario u
                LEFT JOIN 
                    UsuarioPerfil up ON u.Id = up.UsuarioId
                LEFT JOIN 
                    Perfil p ON up.PerfilId = p.Id 
                        WHERE u.Id = @UsuarioId;";
        }

        public string GetPerfil()
        {
            return @"Select Id, Nome, Descricao From Perfil where Id = @UsuarioId";
        }
    }
}