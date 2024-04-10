using NSGE.Domain.Entity.Fabricante;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class FabricanteService : IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        public FabricanteService(IFabricanteRepository repository)
        {
            _fabricanteRepository = repository;
        }
        public IList<Fabricante> GetAllFabricantes()
        {
            return _fabricanteRepository.GetAllFabricantes();
        }

        public IEnumerable<Fabricante> Pesquisar(string value)
        {
            return _fabricanteRepository.Pesquisar(value);
        }
    }
}