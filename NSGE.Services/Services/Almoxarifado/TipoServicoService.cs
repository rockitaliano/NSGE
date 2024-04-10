using NSGE.Domain.Entity.Almoxarifado;
using NSGE.Infrastructure.Repositories.Interfaces.Almoxarifado;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services.Almoxarifado
{
    public class TipoServicoService : ITipoServicoService
    {
        private readonly ITipoServicoRepository _repository;

        public TipoServicoService(ITipoServicoRepository repository)
        {
            _repository = repository;
        }

        public IList<TipoServico> Filtrar()
        {
            return _repository.Filtrar();
        }
    }
}