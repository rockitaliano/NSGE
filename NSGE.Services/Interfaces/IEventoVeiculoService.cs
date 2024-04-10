using NSGE.Domain.Entity.Associative;

namespace NSGE.Services.Interfaces
{
    public interface IEventoVeiculoService
    {
        public IList<EventoVeiculo> ListBy(string eventoId);
    }
}