using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.AgendaTecnica;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class AgendaTecnicaRepository : IAgendaTecnicaRepository
    {
        private readonly IDapperContext _context;
        private readonly AgendaTecnicaSQLContainer _container;
        public AgendaTecnicaRepository(IDapperContext context, AgendaTecnicaSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public IList<AgendaTecnica> CarregarAgendaDoEvento(string eventoId)
        {
            var query = _container.RetornarAgenda();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@IdEvento", eventoId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<AgendaTecnica>(query, parameter).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}