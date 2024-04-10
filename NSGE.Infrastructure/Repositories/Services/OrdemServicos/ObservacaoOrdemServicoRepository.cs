using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Operacional;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Operacional;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ObservacaoOrdemServicoRepository : IObservacaoOrdemServicoRepository
    {
        private readonly IDapperContext _context;
        private readonly OrdemServicoSQLContainer _container;

        public ObservacaoOrdemServicoRepository(IDapperContext context, OrdemServicoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public ObservacaoOrdemServico CarregarPorOrdemServico(string idOrdemServico)
        {
            var query = _container.Filtrar();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", idOrdemServico, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<ObservacaoOrdemServico>(query, parameter).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw new NSGECustomException("", ex.Message);
            }
        }
    }
}