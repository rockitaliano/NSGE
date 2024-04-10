using NSGE.Domain.Entity.Operacional;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class ManutencaoService : IManutencaoService
    {
        private readonly IManutencaoRepository _repository;
        public ManutencaoService(IManutencaoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<Manutencao>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}