using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Source;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ServiceSourceRepository : IServiceSourceRepository
    {
        private readonly IDapperContext _context;
        private readonly SourceServiceSQLContainer _container;
        public ServiceSourceRepository(IDapperContext context, SourceServiceSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public void Delete(string id)
        {
            var query = _container.Delete();
            var parameter = new DynamicParameters(query);

            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                connection.Execute(query, parameter);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<Source> GetSources()
        {
            var query = _container.GetSources();

            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Source>(query).ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<Source> ListarSource(TipoTelaEnum tela, TipoCampoEnum campo)
        {
            var query = _container.Filter();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@tela", tela.GetEnumValue(), DbType.String);
                parameters.Add("@campo", campo.GetEnumValue(), DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Source>(query, parameters).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new NSGECustomException("", ex.Message);
            }
        }

        public Source LoadId(string id)
        {
            var query = _container.LoadId();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Source>(query, parameters).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Source Update(Source source)
        {
            var query = _container.Update();
            try
            {
                using var _connection = _context.CreateConnection();
                var updatedStatus = _connection.Query<Source>(query, source).FirstOrDefault();
                return updatedStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o Source/Dados Genericos.", ex);
            }
        }
    }
}