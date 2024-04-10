using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Arquivo;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ArquivoRepository : IArquivoRepository
    {
        private readonly IDapperContext _context;
        private readonly ArquivoSQLContainer _container;

        public ArquivoRepository(IDapperContext context, ArquivoSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public IList<Arquivo> ListarPorEvento(string eventoId)
        {
            var query = _container.ListarPorEvento();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@EventoId", eventoId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Arquivo>(query, parameter).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}