using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Security;

namespace NSGE.Infrastructure.Repositories.Interfaces.Usuarios
{
    public interface IUsuarioRepository
    {
        IList<Usuario> GetUsuarios();

        Usuario Load(string Id);
        IList<Usuario> Filter(string login);

        IList<Usuario> List();
        IList<UsuarioPerfil> GetPerfisDoUsuario(string usuarioId);
    }
}