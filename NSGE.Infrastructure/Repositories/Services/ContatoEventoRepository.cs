using Dapper;
using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.ContatoEvento;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ContatoEventoRepository : IContatoEventoRepository
    {
        private readonly IDapperContext _context;
        private readonly ContatoEventoSQLContainer _container;

        public ContatoEventoRepository(IDapperContext context, ContatoEventoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IList<ContatoEvento> RetornarContatoEvento(string eventoId)
        {
            var query = _container.RetornaContatoEvento();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@EventoId", eventoId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<ContatoEvento>(query, parameter).ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}