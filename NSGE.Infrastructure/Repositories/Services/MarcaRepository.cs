using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGEInfrastructureSQLBuilderMarca;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly IDapperContext _context;
        private readonly MarcaSQLContainer _container;
        public MarcaRepository(IDapperContext context, MarcaSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public IEnumerable<Marca> Filtrar(string descricao)
        {
            throw new NotImplementedException();
        }

        public void Insert(Marca marca)
        {
            throw new NotImplementedException();
        }

        public IList<Marca> List()
        {
            var query = _container.List();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Marca>(query).ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Marca ObterMarca(string id)
        {
            var query = _container.ObterMarca();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Marca>(query, parameter).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(Marca marca)
        {
            throw new NotImplementedException();
        }
    }
}
