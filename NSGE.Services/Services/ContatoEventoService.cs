using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class ContatoEventoService : IContatoEventoService
    {
        private readonly IContatoEventoRepository _repository;
        public ContatoEventoService(IContatoEventoRepository repository)
        {
            _repository = repository;
        }
        public IList<ContatoEvento> RetornarContatoEvento(string eventoId)
        {
            var contatoEvento = _repository.RetornarContatoEvento(eventoId);
            return contatoEvento;
        }
    }
}