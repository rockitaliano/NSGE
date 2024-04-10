using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.ContasAPagar;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ContasAPagarRepository : IContasAPagarRepository
    {
        private readonly IDapperContext _context;
        private readonly ContasAPagarSQLContainer _container = new ContasAPagarSQLContainer();

        public ContasAPagarRepository(IDapperContext context)
        {
            _context = context;
        }

        public List<ContasAPagar> Filtrar(ContasAPagarFiltro filtro)
        {
            var query = _container.GetContasAPagar();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@DataInicial", filtro.DataInicial, DbType.Date);
                parameters.Add("@DataFinal", filtro.DataFinal, DbType.Date);

                using var connection = _context.CreateConnection();

                var result = connection.Query<ContasAPagar>(query, parameters);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw;
            }
        }

        public ContasAPagar GetBaixarId(string id)
        {
            var query = _container.GetBaixarPorId();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                parameters.Add("@Id", id, DbType.String);

                var result = connection.Query<ContasAPagar>(query, parameters).SingleOrDefault();

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public List<Empresa> List()
        {
            var query = _container.GetEmpresa();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Empresa>(query);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw;
            }
        }

        public IList<Status> ListarStatusPorTipo(TipoStatusEnum tipo)
        {
            var query = _container.GetStatus();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@EnumValue", tipo, DbType.String);
                using var connection = _context.CreateConnection();

                var result = connection.Query<Status>(query, parameters);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<CentroDeCusto> ListCentroCusto()
        {
            var query = _container.GetCentroCusto();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<CentroDeCusto>(query);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw;
            }
        }

        public IList<PlanoDeContas> ListPlanoContas()
        {
            var query = _container.GetPlanoContas();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<PlanoDeContas>(query);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw;
            }
        }
    }
}