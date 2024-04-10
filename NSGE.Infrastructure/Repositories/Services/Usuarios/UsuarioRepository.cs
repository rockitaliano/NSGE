using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Models.Identity;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces.Usuarios;
using NSGE.Infrastructure.SQLBuilder.Usuarios;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDapperContext _context;
        private readonly UsuariosSQLContainer _container;
        public UsuarioRepository(IDapperContext context, UsuariosSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IList<Usuario> Filter(string login)
        {
            var query = _container.FilterWithRelation();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("Login", login, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Usuario>(query, parameter).ToList();
                
                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new NSGECustomException("", ex.Message);
            }
        }

        public IList<Usuario> GetUsuarios()
        {
            var query = _container.GetUsuarios();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Usuario>(query);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new NSGECustomException("Error GetUsuarios", ex.Message);
            }
        }

        public IList<Usuario> List()
        {
            var query = _container.Listar();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Usuario>(query).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new NSGECustomException("Erro em List", ex.StackTrace);
            }
        }

        public Usuario Load(string Id)
        {
            var query = _container.Load();
            var parameter = new DynamicParameters();
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    parameter.Add("Id", Id, DbType.String);
                    using var connection = _context.CreateConnection();
                    var result = connection.Query<Usuario>(query, parameter).FirstOrDefault();
                    return result;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new NSGECustomException("", ex.Message);
            }
        }

        public IList<UsuarioPerfil> GetPerfisDoUsuario(string usuarioId)
        {
            var query = _container.GetPerfisUsuario();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@UsuarioId", usuarioId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<UsuarioPerfil>(query, parameter).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}