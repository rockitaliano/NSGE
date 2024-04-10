using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.PlanoDeContas;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class PlanoDeContasRepository : IPlanoDeContasRepository
    {
        private IDapperContext _context;
        private readonly PlanoDeContasSQLContainer _container;

        public PlanoDeContasRepository(IDapperContext context, PlanoDeContasSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IEnumerable<ContasAReceber> Filtrar(int? page, ContasAReceberFiltro filtro)
        {
            throw new NotImplementedException();
        }

        public IList<PlanoDeContas> TreeView()
        {
            var query = _container.GetAll();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<PlanoDeContas>(query);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public PlanoDeContas Load(string id)
        {
            var query = _container.Load();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                parameters.Add("@Id", id, DbType.String);

                var result = connection.Query<PlanoDeContas>(query, parameters).FirstOrDefault();

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public List<CentroDeCusto> ListarCentroDeCusto()
        {
            var query = _container.ListarCentroDeCusto();
            using var connection = _context.CreateConnection();
            var result = connection.Query<CentroDeCusto>(query);
            return result.ToList();
        }
    }
}