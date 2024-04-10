using NSGE.Domain.Entity.Almoxarifado;

namespace NSGE.Services.Interfaces
{
    public interface ITipoServicoService
    {
        public IList<TipoServico> Filtrar();
    }
}