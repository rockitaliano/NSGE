using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Operacional;
using NSGE.Domain.Entity.Views;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Operacional;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class OperacionalRepository : IOperacionalRepository
    {
        private readonly IDapperContext _context;
        private readonly OrdemServicoSQLContainer _container = new OrdemServicoSQLContainer();

        public OperacionalRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IList<View_EntradaItens>> GetAllOrdemServicoEntrada()
        {
            var query = _container.GetAllOrdemServicoEntrada();

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<View_EntradaItens>(query);
                return result.ToList();
            }
        }

        public async Task<IList<OrdemServicoGrid>> GetAllOrdemServicoSaida()
        {
            var checklist = _container.GetOrdemServico();
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<OrdemServicoGrid>(checklist);
                return result.ToList();
            }
        }

        public async Task<IList<EstoqueHistorico>> GetAllHistoricoEstoque()
        {
            var historicoEstoque = _container.GetHistoricoEstoque();
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<EstoqueHistorico>(historicoEstoque);
                return result.ToList();
            }
        }

        private string MontarQueryWhere(string query, List<string> where)
        {
            var whereSyntax = "";
            var whereCondicoes = "";

            if (where.Count > 0)
            {
                whereSyntax = "where ";
                whereCondicoes = string.Join(" and ", where);
            }

            return query.Replace("_where_", string.Format("{0}{1}", whereSyntax, whereCondicoes));
        }

        private string MontarQueryToCount(string query)
        {
            query = query.Replace("_select_", "count(1)").Replace("_limit_", "");

            return string.Format("select count(1) from ({0}) as groups", query);
        }

        private string MontarQueryToList(string query, int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;

            return query.Replace("_select_", "*").Replace("_limit_", string.Format("limit {0}, {1}", skip, pageSize));
        }

        public async Task<IList<View_EntradaItens>> ListByTransaction(string idTransaction)
        {
            var query = _container.GetTransationById();
            var parameters = new DynamicParameters();

            try
            {
                using var connection = _context.CreateConnection();
                if (idTransaction != null)
                    parameters.Add("@Id", idTransaction, DbType.String);

                var result = connection.Query<View_EntradaItens>(query, parameters);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}