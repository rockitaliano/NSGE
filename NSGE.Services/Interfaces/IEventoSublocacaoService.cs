using NSGE.Domain.Entity.Associative;

namespace NSGE.Services.Interfaces
{
    public interface IEventoSublocacaoService
    {
        public IList<EventoSublocacao> ListarPorEvento(string idEvento);
    }
}