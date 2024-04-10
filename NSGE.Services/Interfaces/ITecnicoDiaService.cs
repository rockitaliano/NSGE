using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface ITecnicoDiaService
    {
        public IList<TecnicoDia> RetornarTecnicoDia(string AgendaId);
    }
}