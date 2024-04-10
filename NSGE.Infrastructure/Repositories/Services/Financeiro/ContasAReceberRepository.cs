using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.ContasAReceber;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository.Financeiro
{
    public class ContasAReceberRepository : IContasAReceberRepository
    {
        private readonly IDapperContext _context;
        private ContasAReceberSQLContainer _container;

        public ContasAReceberRepository(IDapperContext context, ContasAReceberSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public List<ContasAReceber> GetAll(ContasAReceberFiltro filtro)
        {
            var query = _container.GetAll();
            var parameter = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (filtro != null)
                {
                    parameter.Add("@DataInicial", filtro.DataInicial, DbType.Date);
                    parameter.Add("@DataFinal", filtro.DataFinal, DbType.Date);
                }
                var result = connection.Query<ContasAReceber>(query, parameter);

                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Status> ListarPorTipo(string tipo)
        {
            var query = _container.ListarPorTipo();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@tipo", tipo, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Status>(query, parameter);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }       
    }
}