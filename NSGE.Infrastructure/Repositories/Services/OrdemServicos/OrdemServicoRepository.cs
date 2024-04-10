using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Operacional;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Operacional;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class OrdemServicoRepository : IOrdemServicoRepository
    {
        private readonly IDapperContext _context;

        private readonly OrdemServicoSQLContainer _container;

        public OrdemServicoRepository(IDapperContext context, OrdemServicoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IList<ItemSublocacaoOrdemServicoVersao> ListItemSubLocacaoServicoVersao()
        {
            throw new NotImplementedException();
        }

        public IList<ItemOrdemServicoVersao> ListOSServicoVersao()
        {
            throw new NotImplementedException();
        }

        public OrdemServico Load(string id)
        {
            var query = _container.Load();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<OrdemServico>(query, parameter).FirstOrDefault(x=>x.Id == id);

                return result;
            }
            catch (Exception  ex)
            {

                throw new Exception(""+ ex.StackTrace);
            }
        }
    }
}