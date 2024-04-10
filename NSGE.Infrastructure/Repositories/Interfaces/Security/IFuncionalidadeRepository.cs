using NSGE.Domain.Entity.Security;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IFuncionalidadeRepository
    {
        IList<Funcionalidade> List();

        IList<Funcionalidade> ListarIgnorandoFuncionalidadesDoPerfil(Perfil perfil);
    }
}