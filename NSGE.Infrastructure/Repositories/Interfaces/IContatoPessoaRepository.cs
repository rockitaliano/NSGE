using NSGE.Domain.Entity.Associative;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IContatoPessoaRepository
    {
        public IList<ContatoPessoa> RecuperarPorPessoa(string pessoaId);
    }
}