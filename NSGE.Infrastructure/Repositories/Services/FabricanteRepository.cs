using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Fabricante;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Fabricante;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class FabricanteRepository : IFabricanteRepository
    {
        private readonly IDapperContext _context;
        private FabricanteSQLContainer _container = new FabricanteSQLContainer();

        public FabricanteRepository(IDapperContext context)
        {
            _context = context;
        }

        public IList<Fabricante> GetAllFabricantes()
        {
            var sql = _container.GetFabricantes();
            using (var connection = _context.CreateConnection())
            {
                var result = connection.Query<Fabricante>(sql).ToList();
                return result;
            }
        }

        public IEnumerable<Fabricante> Pesquisar(string value)
        {
            var query = _container.GetName();
            var parameter = new DynamicParameters();
            dynamic result;
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    query += " AND Nome LIKE CONCAT('%', @Value, '%')";
                    parameter.Add("@Value", value, DbType.String);
                }

                using var connection = _context.CreateConnection();

                result = connection.Query<Fabricante>(query, parameter);

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}