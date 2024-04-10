using NSGE.Domain.Entity.Associative;

namespace NSGE.Services.Interfaces
{
    public interface IContatoEventoService
    {
        public IList<ContatoEvento> RetornarContatoEvento(string eventoId);
    }
}