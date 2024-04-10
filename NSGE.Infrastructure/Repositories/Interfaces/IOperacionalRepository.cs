using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Operacional;
using NSGE.Domain.Entity.Views;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IOperacionalRepository
    {
        public Task<IList<OrdemServicoGrid>> GetAllOrdemServicoSaida();
        public Task<IList<View_EntradaItens>> GetAllOrdemServicoEntrada();
        public Task<IList<EstoqueHistorico>> GetAllHistoricoEstoque();
        public Task<IList<View_EntradaItens>> ListByTransaction(string idTransaction);
    }
}