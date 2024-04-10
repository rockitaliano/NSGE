using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IArquivoService
    {
        public IList<Arquivo> ListarPorEvento(string eventoId);
        public void IOLimparPastaTemporaria(string eventoId = null);
    }
}