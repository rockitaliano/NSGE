using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Config;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Base;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IDapperContext _context;
        private readonly BaseSQLContainer _container;

        public BaseRepository(IDapperContext context, BaseSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IList<Sistema> Filter()
        {
            var query = _container.Filter();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Sistema>(query).ToList();
                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new NSGECustomException("", ex.Message);
            }
        }
    }
}