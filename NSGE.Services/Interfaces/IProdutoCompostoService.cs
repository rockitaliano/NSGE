using NSGE.Domain.Entity.Operacional;

namespace NSGE.Services.Interfaces
{
    public interface IProdutoCompostoService
    {
        public Task<IList<ProdutoComposto>> GetProdutos();
    }
}