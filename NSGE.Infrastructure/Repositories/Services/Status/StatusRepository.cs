using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Status;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly IDapperContext _context;
        private readonly StatusSQLContainer _container;
        public StatusRepository(IDapperContext context, StatusSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public DbType? Dbtype { get; private set; }

        public void Delete(string id)
        {
            var query = _container.Delete();
            var parameter = new DynamicParameters();

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

        public IList<Status> Load()
        {
            var query = _container.Load();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Status>(query).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public Status LoadId(string id)
        {
            var query = _container.LoadId();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Status>(query, parameter).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Status Update(Status model)
        {
            var query = _container.Update();
            var parameter = new DynamicParameters();
            try
            {
                if (model.Descricao != null)
                    parameter.Add("@Descricao", model.Descricao, Dbtype.Value);

                if (model.TipoDoCadastro != null)
                    parameter.Add("@TipoDoCadastro", model.TipoDoCadastro, Dbtype.Value);

                if(model.Leitura != null)
                    parameter.Add("@Leitura", model.Leitura, Dbtype.Value);

                using var connection = _context.CreateConnection();
                var updatedStatus = connection.Query<Status>(query, parameter).FirstOrDefault();

                return updatedStatus;
            }
            catch (Exception ex)
            {
                // Registre ou manipule a exceção conforme necessário
                throw new Exception("Ocorreu um erro ao atualizar o status.", ex);
            }

        }
    }
}