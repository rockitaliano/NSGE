using Dapper;
using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.EventoProposta;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class EventoPropostaRepository : IEventoPropostaRepository
    {
        private readonly IDapperContext _context;
        private readonly EventoPropostaSQLContainer _container;
        public EventoPropostaRepository(IDapperContext context, EventoPropostaSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public IList<EventoProposta> RetornarEventoProposta(string eventoId)
        {
            var query = _container.RetornarEventoProposta();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@EventoId", eventoId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<EventoProposta>(query, parameter).ToList();

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}