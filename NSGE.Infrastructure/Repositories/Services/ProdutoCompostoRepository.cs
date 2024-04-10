using Dapper;
using NSGE.Domain.Entity.Operacional;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.ProdutoComposto;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ProdutoCompostoRepository : IProdutoCompostoRepository
    {
        private readonly IDapperContext _context;
        private ProdutoCompostoSQLContainer _produtoComposto = new ProdutoCompostoSQLContainer();

        public ProdutoCompostoRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IList<ProdutoComposto>> GetProdutoCompostoAsync()
        {
            var produtoComposto = _produtoComposto.GetAllProdutoComposto();
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ProdutoComposto>(produtoComposto);
                return result.ToList();
            }
        }
    }
}