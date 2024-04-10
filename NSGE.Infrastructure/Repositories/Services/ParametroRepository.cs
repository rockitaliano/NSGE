using Dapper;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Parametro;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly IDapperContext _context;
        private readonly ParametroSQLBuilder _parametroSQLBuilder;
        public ParametroRepository(IDapperContext context, ParametroSQLBuilder parametro)
        {
            _context = context;
            _parametroSQLBuilder = parametro;
        }
        public Parametro Filter(string key)
        {
            var result = new Parametro();
            var query = _parametroSQLBuilder.Filter();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@Key", key, DbType.String);
                using var connection = _context.CreateConnection();
                result = connection.Query<Parametro>(query, parameter).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}