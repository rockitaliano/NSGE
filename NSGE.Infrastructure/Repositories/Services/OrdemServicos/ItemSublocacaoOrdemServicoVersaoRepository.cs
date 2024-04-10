using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Operacional;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ItemSublocacaoOrdemServicoVersaoRepository : IItemSublocacaoOrdemServicoVersaoRepository
    {
        private readonly IDapperContext _context;
        private readonly ItemSublocacaoOrdemServicoVersaoSQLContainer _container;

        public ItemSublocacaoOrdemServicoVersaoRepository(IDapperContext context, 
                                                          ItemSublocacaoOrdemServicoVersaoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public int GetVersao(string idOrdemServico)
        {
            var query = _container.GetVersao2();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@IdOrdemServico", idOrdemServico, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<int>(query, parameter);
                if (result == null) 
                {
                    return 0;
                }
                else
                    return result.AsEnumerable().Count();
            }
            catch (Exception ex) 
            {
                throw new NSGECustomException("", ex.Message);
            }
        }
    }
}