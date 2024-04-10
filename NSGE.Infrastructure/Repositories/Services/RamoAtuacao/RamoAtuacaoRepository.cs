using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.RamoAtuacao;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class RamoAtuacaoRepository : IRamoAtuacaoRepository
    {
        private readonly IDapperContext _context;
        private readonly RamoAtuacaoSQLContainer _container;

        public RamoAtuacaoRepository(IDapperContext context, RamoAtuacaoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IEnumerable<RamoAtuacao> Filtrar()
        {
            var query = _container.Filtrar();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<RamoAtuacao>(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}