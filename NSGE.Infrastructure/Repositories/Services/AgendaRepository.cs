using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Agenda;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly IDapperContext _context;
        private readonly AgendaSQLContainer _container = new AgendaSQLContainer();

        public AgendaRepository(IDapperContext context)
        {
            _context = context;
        }

        public IList<AgendaTecnica> ListarAgenda(DateTime? inicio, DateTime? fim)
        {
            var sql = _container.GetAgendaTecnica();
            try
            {
                using var connection = _context.CreateConnection();

                var queryParameters = new DynamicParameters();

                if (inicio.HasValue)
                {
                    sql += " AND PR.DataDoEvento >= @DataInicial";
                    queryParameters.Add("@DataInicial", inicio.Value, DbType.DateTime);
                }

                if (fim.HasValue)
                {
                    sql += " AND PR.DataDoEvento <= @DataFinal";
                    queryParameters.Add("@DataFinal", fim.Value, DbType.DateTime);
                }

                var agenda = connection.Query<AgendaTecnica>(sql, queryParameters);

                return agenda.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<AgendaTecnica> RetornarAgenda(string idEvento)
        {
            var query = _container.RetornaAgenda();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@EventoId", idEvento, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<AgendaTecnica>(query, parameter);

                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}