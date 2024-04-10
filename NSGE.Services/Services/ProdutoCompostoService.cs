using NSGE.Domain.Entity.Operacional;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class ProdutoCompostoService : IProdutoCompostoService
    {
        private readonly IProdutoCompostoRepository _repository;

        public ProdutoCompostoService(IProdutoCompostoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ProdutoComposto>> GetProdutos()
        {
            return await _repository.GetProdutoCompostoAsync();
        }
    }
}