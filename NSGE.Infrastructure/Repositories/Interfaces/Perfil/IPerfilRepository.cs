using NSGE.Domain.Entity.Security;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IPerfilRepository
    {
        IList<Perfil> Listar(Usuario user);
        IList<Perfil> Load();
        Perfil LoadForId(string id);
        IList<Perfil> Filtrar(string nome);
    }
}