using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class ContatoPessoaService : IContatoPessoaService
    {
        private readonly IContatoPessoaRepository _contatoPessoaRepository;
        public ContatoPessoaService(IContatoPessoaRepository contatoPessoaRepository)
        {
            _contatoPessoaRepository = contatoPessoaRepository;
        }
        public IList<ContatoPessoa> RecuperarPorPessoa(string pessoaId)
        {
            return _contatoPessoaRepository.RecuperarPorPessoa(pessoaId).Where(x=> x.PessoaId == pessoaId).ToList();
        }
    }
}