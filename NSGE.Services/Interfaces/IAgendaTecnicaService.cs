using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IAgendaTecnicaService
    {
        public IList<AgendaTecnica> CarregarAgendaDoEvento(string eventoId);
    }
}