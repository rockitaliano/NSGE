using Dapper;
using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.EventoEquipe;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class EventoEquipeRepository : IEventoEquipeRepository
    {
        private readonly IDapperContext _context;
        private readonly EventoEquipeSQLContainer _container;

        public EventoEquipeRepository(IDapperContext context, EventoEquipeSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IList<EventoEquipe> ListarPorEvento(string eventoId)
        {
            var query = _container.ListarPorEvento();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@EventoId", eventoId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<EventoEquipe>(query, parameter).ToList();
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}