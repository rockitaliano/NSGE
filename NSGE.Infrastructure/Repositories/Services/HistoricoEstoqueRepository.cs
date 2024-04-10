using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Operacional.HistoricoEstoque;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class HistoricoEstoqueRepository : IHistoricoEstoqueRepository
    {
        public readonly IDapperContext _context;
        public readonly HistoricoEstoqueSQLContainer _container;

        public HistoricoEstoqueRepository(IDapperContext context, HistoricoEstoqueSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public async Task<IList<HistoricoEstoque>> GetAllOnlyThisYear()
        {
            var query = _container.GetAllHistoricoEstoque();
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<HistoricoEstoque>(query);
                return result.ToList();
            }
        }

        public IList<Status> ListarPorTipo(string tipo)
        {
            var sql = _container.ListarPorTipo();
            string tipoString = tipo.ToString();

            using (var connection = _context.CreateConnection())
            {
                sql = sql.Replace("{WHERE}", tipoString);
                var result = connection.Query<Status>(sql);
                return result.ToList();
            }
        }
    }
}