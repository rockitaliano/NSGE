using NSGE.Domain.Entity.Financeiro;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces.Financeiro;

namespace NSGE.Services.Services.Financeiro
{
    public class ContasAReceberService : IContasAReceberService
    {
        private readonly IContasAReceberRepository _repository;
        public ContasAReceberService(IContasAReceberRepository repository)
        {
            _repository = repository;
        }
        public List<ContasAReceber> GetAll(ContasAReceberFiltro filtro)
        {
            var contasAReceber = new List<ContasAReceber>();
            var result = _repository.GetAll(filtro);
            foreach (var item in result)
            {
                contasAReceber.Add(item);
            }
            return contasAReceber;
        }
    }
}