using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IAgendaRepository
    {
        public IList<AgendaTecnica> ListarAgenda(DateTime? inicio, DateTime? fim);

        public IList<AgendaTecnica> RetornarAgenda(string idEvento);
    }
}