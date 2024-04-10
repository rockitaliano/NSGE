using NSGE.Domain.Entity.Associative;

namespace NSGE.Services.Interfaces
{
    public interface IContatoPessoaService
    {
        public IList<ContatoPessoa> RecuperarPorPessoa(string pessoaId);
    }
}