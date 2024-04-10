using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Almoxarifado;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces.Almoxarifado;
using NSGE.Infrastructure.SQLBuilder.TipoServico;

namespace NSGE.Infrastructure.Repositories.ImplementRepository.Almoxarifado
{
    public class TipoServicoRepository : ITipoServicoRepository
    {
        private IDapperContext _context;
        private readonly TipoServicoSQLContainer _container;

        public TipoServicoRepository(IDapperContext context, TipoServicoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IList<TipoServico> Filtrar()
        {
            var query = _container.Filtrar();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<TipoServico>(query);
                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}