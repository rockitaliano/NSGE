using Dapper;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Evento;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly IDapperContext _context;
        private readonly EventoSQLContainer _container = new EventoSQLContainer();

        public EventoRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IList<EventoGrid>> ListarEventos()
        {
            var query = _container.GetTodosEventos();

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<EventoGrid>(query);
                return result.ToList();
            }
        }

        public async Task<IList<EventoGrid>> Filtrar(EventoGrid model)
        {
            var sql = _container.GetEventos();
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(model.NumeroDaOs))
            {
                sql += " AND E.NumeroDaOS = @numeroOS";
                parameters.Add("@numeroOS", model.NumeroDaOs.Trim(), DbType.String);
            }

            if (!string.IsNullOrEmpty(model.NomeEvento))
            {
                sql += " AND E.Nome LIKE @nomeEvento";
                parameters.Add("@nomeEvento", $"%{model.NomeEvento}%", DbType.String);
            }

            if (!string.IsNullOrEmpty(model.NomeCliente))
            {
                sql += " AND P.Nome LIKE @nomeCliente";
                parameters.Add("@nomeCliente", $"%{model.NomeCliente}%", DbType.String);
            }
            if (model.DataEvento != null)
            {
                sql += " AND  E.InicioDoEvento BETWEEN @dataEvento AND @dataEvento";
                parameters.Add("@dataEvento", model.DataEvento, DbType.DateTime);
            }

            if (model.Endereco != null)
            {
                sql += " AND en.Logradouro LIKE @Endereco";
                parameters.Add("@Endereco", $"%{model.Endereco}%", DbType.String);
            }              


            using (var connection = _context.CreateConnection())
            {
                var evento = connection.Query<EventoGrid>(sql, parameters).ToList();

                return evento;
            }
        }

        public Evento CarregarOS(string numeroDaOS)
        {
            var sql = _container.GetOs();

            using var connection = _context.CreateConnection();

            var carregarOs = connection.Query<Evento>(sql);

            return null;
        }

        public Evento RetornarEvento(string idEvento)
        {
            var query = _container.RetonarEvento();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", idEvento, DbType.String);
                using var connection = _context.CreateConnection();

                var result = connection.Query<Evento>(query, parameter).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IList<EventoPessoa> ListarPorEvento(string eventoId)
        {
            var query = _container.ListarPorEvento();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@EventoId", eventoId, DbType.String);
                using var connection = _context.CreateConnection();

                var result = connection.Query<EventoPessoa>(query, parameter).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<Evento> QueryEventos()
        {
            var query = _container.QueryEventos();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Evento>(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("erro QueryEventos em EventoRepository", ex.Message);
            }
        }
    }
}