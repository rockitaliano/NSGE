using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces.Agenda
{
    public interface IAgendaService
    {
        public IList<AgendaTecnica> ListarAgenda(DateTime? inicio, DateTime? fim);
        public IList<AgendaTecnica> Load(string id);
        public Task<IList<AgendaTecnica>> CarregarAgendaDoEvento(string eventoId);
    }
}