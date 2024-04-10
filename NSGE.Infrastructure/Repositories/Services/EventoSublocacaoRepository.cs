using Dapper;
using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.EventoSublocacao;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class EventoSublocacaoRepository : IEventoSublocacaoRepository
    {
        private IDapperContext _context;
        private readonly EventoSublocacaoSQLContainer _container;
        public EventoSublocacaoRepository(IDapperContext dapperContext, EventoSublocacaoSQLContainer container)
        {
            _context = dapperContext;
            _container = container;

        }
        public IList<EventoSublocacao> ListarPorEvento(string idEvento)
        {
            var query = _container.ListarPorEvento();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@EventoId", idEvento, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<EventoSublocacao>(query, parameter).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}