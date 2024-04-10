using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IAgendaTecnicaRepository
    {
        public IList<AgendaTecnica> CarregarAgendaDoEvento(string eventoId);
    }
}