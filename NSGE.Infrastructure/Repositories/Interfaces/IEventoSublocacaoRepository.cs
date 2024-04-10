using NSGE.Domain.Entity.Associative;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IEventoSublocacaoRepository
    {
        public IList<EventoSublocacao> ListarPorEvento(string idEvento);
    }
}