using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Notificacao;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly IDapperContext _context;
        private readonly NotificacaoSQLContainer _container;
        public NotificacaoRepository(IDapperContext context, NotificacaoSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public bool Delete(string id)
        {
            var query = _container.Delete();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var rowsAffected = connection.Query(query, parameter).FirstOrDefault();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<Notificacao> Filtrar(string nome, string tipo)
        {
            var query = _container.Filtrar();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Nome", nome, DbType.String);
                parameter.Add("@Tipo", tipo, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Notificacao>(query, parameter).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("", ex.Message);
            }
        }

        public bool Insert(Notificacao model)
        {
            var query = _container.Insert();
            var parameter = new DynamicParameters();
            try
            {
                if (model.Id == null)
                {
                    var guid = Guid.NewGuid().ToString("N").Substring(0, 32);
                    parameter.Add("@Id", guid, DbType.String);
                }
                parameter.Add("@Nome", model.Nome, DbType.String);
                parameter.Add("@Email", model.Email, DbType.String);
                parameter.Add("@Tipo", model.Tipo, DbType.String);

                using var connection = _context.CreateConnection();
                var rowsAffected = connection.Execute(query, parameter);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException("", ex.Message);
            }
        }

        public Notificacao Load(string id)
        {
            var query = _container.Load();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Notificacao>(query, parameter).FirstOrDefault ();

                return result;

            }
            catch (Exception ex)
            {
                throw new NSGECustomException("", ex.Message);
            }
        }

        public bool Update(Notificacao model)
        {
            var query = _container.Update();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Execute(query, model);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("", ex.Message);
            }
        }
    }
}
