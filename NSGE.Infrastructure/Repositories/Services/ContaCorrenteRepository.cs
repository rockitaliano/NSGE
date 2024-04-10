using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.ContaCorrente;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly IDapperContext _context;
        private readonly ContaCorrenteSQLContainer _container;

        public ContaCorrenteRepository(IDapperContext context, ContaCorrenteSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IList<ContaCorrente> GetAll()
        {
            var query = _container.GetContasCorrente();
            var parameter = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<ContaCorrente>(query);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<Banco> PesquisarBancosPorEmpresa(string idEmpresa)
        {
            var query = _container.PesquisarBancosPorEmpresa();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@IdDaEmpresa", idEmpresa, DbType.String);

                using var connection = _context.CreateConnection();

                var result = connection.Query<Banco>(query, parameter);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<ContaCorrente> PesquisarPorEmpresaEBanco(string idEmpresa, string idBanco)
        {
            var query = _container.PesquisarPorEmpresaEBanco();
            var parameter = new DynamicParameters();
            try
            {
                if (string.IsNullOrEmpty(idEmpresa))
                    parameter.Add("IdDaEmpresa", idEmpresa, DbType.String);

                if (string.IsNullOrEmpty(idBanco))
                    parameter.Add("IdDoBanco", idBanco, DbType.String);

                using var connection = _context.CreateConnection();

                var result = connection.Query<ContaCorrente>(query, parameter);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}