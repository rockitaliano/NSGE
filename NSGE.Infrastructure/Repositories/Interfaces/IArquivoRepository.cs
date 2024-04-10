using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IArquivoRepository
    {
        public IList<Arquivo> ListarPorEvento(string eventoId);
    }
}