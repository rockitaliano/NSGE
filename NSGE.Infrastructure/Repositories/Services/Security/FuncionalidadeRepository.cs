using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Security;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Security;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class FuncionalidadeRepository : IFuncionalidadeRepository
    {
        private readonly IDapperContext _context;
        private readonly FuncionalidadeSQLContainer _container;
        public FuncionalidadeRepository(IDapperContext context, FuncionalidadeSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public IList<Funcionalidade> List()
        {
            var query = _container.Funcionalidade();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Funcionalidade>(query).ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IList<Funcionalidade> ListarIgnorandoFuncionalidadesDoPerfil(Perfil perfil)
        {
            var query = _container.List();
            var parameter = new DynamicParameters();

            try
            {
                // Obtém os IDs das funcionalidades associadas ao perfil
                List<string> funcionalidadeIds = perfil.Funcionalidades.Select(f => f.FuncionalidadeId).ToList();

                // Adiciona os IDs das funcionalidades ao DynamicParameters
                for (int i = 0; i < funcionalidadeIds.Count; i++)
                {
                    parameter.Add($"gp{i + 1}", funcionalidadeIds[i]);
                }
                using var connection = _context.CreateConnection();
                // Executa a consulta SQL com os parâmetros dinâmicos
                var funcionalidades = connection.Query<Funcionalidade>(query, parameter).ToList();

                return funcionalidades;

            }
            catch (Exception ex)
            {
                throw new NSGECustomException("erro em ListarIgnorandoFuncionalidadesDoPerfil ", ex.Message);
            }
        }
    }
}