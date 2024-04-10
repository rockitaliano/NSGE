using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IHistoricoEstoqueRepository
    {
        public Task<IList<HistoricoEstoque>> GetAllOnlyThisYear();
        public IList<Status> ListarPorTipo(string tipo);        
    }
}