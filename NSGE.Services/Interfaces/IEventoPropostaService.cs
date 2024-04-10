using NSGE.Domain.Entity.Associative;

namespace NSGE.Services.Interfaces
{
    public interface IEventoPropostaService
    {
        public IList<EventoProposta> RetornarEventoProposta(string eventoId);
    }
}