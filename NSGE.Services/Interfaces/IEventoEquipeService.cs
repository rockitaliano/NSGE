using NSGE.Domain.Entity.Associative;

namespace NSGE.Services.Interfaces
{
    public interface IEventoEquipeService
    {
        public IList<EventoEquipe> ListarPorEvento(string eventoId);
    }
}