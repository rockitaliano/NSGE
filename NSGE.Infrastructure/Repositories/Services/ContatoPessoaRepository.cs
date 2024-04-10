using Dapper;
using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.ContatoPessoa;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ContatoPessoaRepository : IContatoPessoaRepository
    {
        private readonly IDapperContext _context;
        private readonly ContatoPessoaSQLContainer _container;
        public ContatoPessoaRepository(IDapperContext context, ContatoPessoaSQLContainer container)
        {
            _context = context;
            _container = container;
        }
        public IList<ContatoPessoa> RecuperarPorPessoa(string pessoaId)
        {
            var query = _container.RecuperarPessoa();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@Id", pessoaId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<ContatoPessoa>(query, parameter).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}