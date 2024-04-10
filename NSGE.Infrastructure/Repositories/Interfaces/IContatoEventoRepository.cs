using NSGE.Domain.Entity.Associative;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IContatoEventoRepository
    {
        public IList<ContatoEvento> RetornarContatoEvento(string eventoId);
    }
}