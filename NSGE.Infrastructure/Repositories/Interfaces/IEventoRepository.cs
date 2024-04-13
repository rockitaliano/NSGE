using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IEventoRepository
    {
        public Task<IList<EventoGrid>> ListarEventos(int? page, int? pageSize);
        public Task<IList<EventoGrid>> Filtrar(EventoGrid model);
        public Evento CarregarOS(string numeroDaOS);
        public Evento RetornarEvento(string idEvento);
        public IList<EventoPessoa> ListarPorEvento(string eventoId);
        IList<Evento> QueryEventos();

    }
}