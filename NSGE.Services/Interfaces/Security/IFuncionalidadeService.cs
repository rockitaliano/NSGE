using NSGE.Domain.Entity.Security;

namespace NSGE.Services.Interfaces.Security
{
    public interface IFuncionalidadeService
    {
        IList<Funcionalidade> List();
        IList<Funcionalidade> ListarIgnorandoFuncionalidadesDoPerfil(Perfil perfil);
    }
}