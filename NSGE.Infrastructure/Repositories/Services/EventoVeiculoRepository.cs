using Dapper;
using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.EventoVeiculo;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class EventoVeiculoRepository : IEventoVeiculoRepository
    {
        private readonly IDapperContext _context;
        private readonly EventoVeiculoSQLContainer _container;
        public EventoVeiculoRepository(IDapperContext context, EventoVeiculoSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public IList<EventoVeiculo> ListBy(string eventoId)
        {
            var query = _container.ListarPor();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@EventoId", eventoId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<EventoVeiculo>(query, parameter).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}