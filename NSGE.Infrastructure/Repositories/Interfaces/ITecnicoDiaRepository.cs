using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface ITecnicoDiaRepository
    {
        public IList<TecnicoDia> RetornarTecnicoDia(string AgendaId);
    }
}