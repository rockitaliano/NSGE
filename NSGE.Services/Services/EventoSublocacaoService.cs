using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class EventoSublocacaoService : IEventoSublocacaoService
    {
        private readonly IEventoSublocacaoRepository _repository;
        public EventoSublocacaoService(IEventoSublocacaoRepository repository )
        {
            _repository = repository;
        }
        public IList<EventoSublocacao> ListarPorEvento(string idEvento)
        {
            return _repository.ListarPorEvento(idEvento);
        }
    }
}