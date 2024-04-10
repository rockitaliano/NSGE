using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.TecnicoDia;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class TecnicoDiaRepository : ITecnicoDiaRepository
    {
        private readonly IDapperContext _context;
        private readonly TecnicoDiaSQLContainer _container;
        public TecnicoDiaRepository(IDapperContext context, TecnicoDiaSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public IList<TecnicoDia> RetornarTecnicoDia(string AgendaId)
        {
            var query = _container.RetornarTecnico();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@AgendaId", AgendaId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<TecnicoDia>(query, parameter).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}