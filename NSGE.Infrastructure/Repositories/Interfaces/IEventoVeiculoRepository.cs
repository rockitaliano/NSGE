using NSGE.Domain.Entity.Associative;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IEventoVeiculoRepository
    {
        public IList<EventoVeiculo> ListBy(string eventoId);
    }
}