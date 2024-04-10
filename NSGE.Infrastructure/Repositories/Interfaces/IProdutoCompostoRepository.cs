using NSGE.Domain.Entity.Operacional;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IProdutoCompostoRepository
    {
        public Task<IList<ProdutoComposto>> GetProdutoCompostoAsync();
    }
}