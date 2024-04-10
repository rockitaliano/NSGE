using NSGE.Domain.Entity.Almoxarifado;

namespace NSGE.Infrastructure.Repositories.Interfaces.Almoxarifado
{
    public interface ITipoServicoRepository
    {
        public IList<TipoServico> Filtrar();
    }
}