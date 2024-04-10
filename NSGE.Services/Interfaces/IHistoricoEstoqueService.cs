using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IHistoricoEstoqueService
    {
        public Task<IList<HistoricoEstoque>> GetHistoricoEstoque();
        public IEnumerable<Status> ListarPorTipo(TipoStatusEnum tipo);

    }
}