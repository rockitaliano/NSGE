using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class EventoPropostaService : IEventoPropostaService
    {
        private readonly IEventoPropostaRepository _repository;
        public EventoPropostaService(IEventoPropostaRepository repository)
        {
            _repository = repository;
        }
        public IList<EventoProposta> RetornarEventoProposta(string eventoId)
        {
            return _repository.RetornarEventoProposta(eventoId);
        }
    }
}