using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IEventoService
    {
        public Task<IList<EventoGrid>> ListarEventos();
        public Task<IList<EventoGrid>> Filtrar(EventoGrid model);
        public Evento CarregarOS(string numeroDaOS);
        public Task<Evento> Load(string id, bool carregarAgenda);
        public Task<Evento> RetornarEvento(string idEvento);
        public IList<Evento> QueryEventos();
    }
}