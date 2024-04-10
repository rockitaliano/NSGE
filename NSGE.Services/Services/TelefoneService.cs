using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _repository;
        public TelefoneService(ITelefoneRepository repository)
        {
            _repository = repository;
        }
        public void ExcluirPorContato(string contatoId)
        {
            _repository.ExcluirPorContato(contatoId);
        }
    }
}