using NSGE.Domain.Entity.Security;

namespace NSGE.Services.Interfaces
{
    public interface IPerfilService
    {
        IList<Perfil> ListarIgnorandoPerfisDoUsuario(Usuario user);
        IList<Perfil> Load();
        Perfil LoadForId(string id);
        IList<Perfil> Filtrar(string nome);
    }
}
