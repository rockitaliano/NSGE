using Dapper;
using NSGE.Domain.Entity.Operacional;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Operacional;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly IDapperContext _context;
        private ManutencaoSQLContainer _container = new ManutencaoSQLContainer();
        public ManutencaoRepository(IDapperContext context)
        {
            _context = context;
        }
        public async Task<IList<Manutencao>> GetAll()
        {
            var sql = _container.GetAll();
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Manutencao>(sql);
                return result.ToList();
            }
        }
    }
}