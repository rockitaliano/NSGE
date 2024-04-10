using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class EventoEquipeService : IEventoEquipeService
    {
        private readonly IEventoEquipeRepository _repository;

        public EventoEquipeService(IEventoEquipeRepository repository)
        {
            _repository = repository;
        }

        public IList<EventoEquipe> ListarPorEvento(string eventoId)
        {
            return _repository.ListarPorEvento(eventoId);
        }
    }
}