using NSGE.Domain.Entity.Associative;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class EventoVeiculoService : IEventoVeiculoService
    {
        private readonly IEventoVeiculoRepository _repository;
        public EventoVeiculoService(IEventoVeiculoRepository repository)
        {
            _repository = repository;
        }
        public IList<EventoVeiculo> ListBy(string eventoId)
        {
            return _repository.ListBy(eventoId);
        }
    }
}