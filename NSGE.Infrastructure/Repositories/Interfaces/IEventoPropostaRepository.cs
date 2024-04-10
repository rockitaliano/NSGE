using NSGE.Domain.Entity.Associative;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IEventoPropostaRepository
    {
        public IList<EventoProposta> RetornarEventoProposta(string eventoId);
    }
}