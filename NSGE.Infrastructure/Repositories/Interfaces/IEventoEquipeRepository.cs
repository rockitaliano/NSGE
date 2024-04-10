using NSGE.Domain.Entity.Associative;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IEventoEquipeRepository
    {
        public IList<EventoEquipe> ListarPorEvento(string eventoId);
    }
}