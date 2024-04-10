using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Security;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Perfil;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class PerfilRepository : IPerfilRepository
    {
        private IDapperContext _context;
        private readonly PerfilSQLContainer _container;
        DynamicParameters parameters = new DynamicParameters();
        public PerfilRepository(IDapperContext context, PerfilSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public IList<Perfil> Listar(Usuario user)
        {
            var query = _container.ListarIgnorandoPerfisDoUsuario();
            var result = new List<Perfil>();
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    result = connection.Query<Perfil>(query).ToList();
                }
               
                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new NSGECustomException("Erro query ListarIgnorandoPerfisDoUsuario", ex.Message);
            }
        }
        public IList<Perfil> Load()
        {
            var query = _container.Filtrar();
            var result = new List<Perfil>();
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    result = connection.Query<Perfil>(query).ToList();
                }
                return result.OrderBy(x => x.Nome).ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new NSGECustomException("Erro query Filtrar", ex.Message);
            }
        }

        public Perfil LoadForId(string id)
        {
            var query = _container.ListarPorID();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Perfil>(query, parameter).FirstOrDefault();

                return result;

            }
            catch (Exception ex)
            {
                throw new NSGECustomException("", ex.Message);
            }
        }

        public IList<Perfil> Filtrar(string nome)
        {
            var query = _container.FiltrarPorNome();
            var queryAll = _container.Filtrar();
            try
            {
                using var connection = _context.CreateConnection();
                if (nome != null)
                {
                    var nomeParametrizado = $"%{nome}%";
                    parameters.Add("@Nome", nomeParametrizado, DbType.String);
                    var result = connection.Query<Perfil>(query, parameters).ToList();
                    return result;
                }
                else
                {
                    var resultAll = connection.Query<Perfil>(queryAll).ToList();
                    return resultAll;
                }
                    
            }
            catch (Exception ex)
            {
                throw new NSGECustomException("Erro no Filtrar ", ex.StackTrace);
            }
        }
    }
}