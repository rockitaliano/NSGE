using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _repository;
        public ContatoService(IContatoRepository repository)
        {
            _repository = repository;
        }

        public Contato Load(string id)
        {
            return _repository.Load(id);
        }

        public void Update(Contato item)
        {
            throw new NotImplementedException();
        }
    }
}