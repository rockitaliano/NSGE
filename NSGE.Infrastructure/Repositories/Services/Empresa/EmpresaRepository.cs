using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Empresa;
using System.Data;
using System.Text;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IDapperContext _context;
        private readonly EmpresaSQLContainer _container;
        public EmpresaRepository(IDapperContext context, EmpresaSQLContainer container)
        {
            _context = context;
            _container = container;

        }

        public int Delete(string id)
        {
            var query = _container.Delete();
            var parameter = new DynamicParameters();
            try
            {
                if (id != null)
                {
                    parameter.Add("@Id", id, DbType.String);
                    using var connection = _context.CreateConnection();
                    var result = connection.Execute(query, parameter);
                    return result;
                }
                else
                    throw new ArgumentNullException(nameof(id), "O ID não pode ser nulo.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao excluir os dados.", ex);
            }
        }

        public IList<Empresa> GetAll()
        {
            var query = _container.GetAll();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Empresa>(query).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Empresa Load(string id)
        {
            var query = _container.LoadId();
            var parameter = new DynamicParameters();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    parameter.Add("@Id", id, DbType.String);
                }
                using var connection = _context.CreateConnection();
                var result = connection.Query<Empresa> (query, parameter).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Empresa Update(Empresa empresa)
        {
            var query = _container.Update();
            try
            {
                using var connection = _context.CreateConnection();
                connection.Execute(query, empresa);
                return empresa;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar empresa.", ex);
            }
        }
    }
}
