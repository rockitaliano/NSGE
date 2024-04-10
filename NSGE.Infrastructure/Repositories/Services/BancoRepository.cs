using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Banco;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class BancoRepository : IBancoRepository
    {
        private IDapperContext _context;
        private BancoSQLContainer _container;

        public BancoRepository(IDapperContext context, BancoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IEnumerable<Banco> ListarBancos()
        {
            var query = _container.GetBancos();

            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Banco>(query);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IEnumerable<Banco> Pesquisar(string value)
        {
            var query = _container.PesquisarBanco();
            var parameter = new DynamicParameters();
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    query += " AND Id LIKE CONCAT('%', @Value, '%') OR Descricao LIKE CONCAT('%', @Value, '%')";
                    parameter.Add("@Value", value, DbType.String);
                }

                using var connection = _context.CreateConnection();

                var result = connection.Query<Banco>(query, parameter);

                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}