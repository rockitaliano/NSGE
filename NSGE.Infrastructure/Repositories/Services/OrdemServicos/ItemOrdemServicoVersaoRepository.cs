using Dapper;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Operacional;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ItemOrdemServicoVersaoRepository : IItemOrdemServicoVersaoRepository
    {
        private readonly IDapperContext _context;
        private readonly ItemOrdemServicoVersaoSQLContainer _container;
        public ItemOrdemServicoVersaoRepository(IDapperContext context, 
                                                ItemOrdemServicoVersaoSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public int GetVersao(string idOrdemServico)
        {
            var query = _container.GetVersao();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@IdOrdemServico", idOrdemServico, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<int>(query, parameter).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}