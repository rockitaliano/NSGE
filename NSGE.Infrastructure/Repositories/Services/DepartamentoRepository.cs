using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Departamento;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly IDapperContext _context;
        private readonly DepartamentoSQLContainer _container;

        public DepartamentoRepository(IDapperContext context, DepartamentoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public Departamento Create(Departamento model)
        {
            var query = _container.Create();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.ExecuteScalar<Departamento>(query, model);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("", ex.Message);
            }
        }

        public int Delete(string id)
        {
            var query = _container.Delete();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Execute(query, parameter);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Departamento> List()
        {
            var query = _container.List();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = connection.Query<Departamento>(query).ToList();
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Departamento LoadId(string id)
        {
            var query = _container.LoadId();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Departamento> (query, parameter).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Departamento Update(Departamento model)
        {
            var query = _container.Update();
            try
            {
                using var connection = _context.CreateConnection();
                connection.Execute(query, model);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}