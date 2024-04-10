using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Operacional;
using NSGE.Domain.Entity.Views;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class OperacionalService : IOperacionalService
    {
        private readonly IOperacionalRepository _repository;

        public OperacionalService(IOperacionalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<EstoqueHistorico>> GetAllHistoricoEstoque()
        {
            return await _repository.GetAllHistoricoEstoque();
        }

        public async Task<IList<View_EntradaItens>> GetAllOrdemServicoEntrada()
        {
            return await _repository.GetAllOrdemServicoEntrada();
        }

        public async Task<IList<OrdemServicoGrid>> GetAllOrdemServicoSaida()
        {
            return await _repository.GetAllOrdemServicoSaida();
        }

        public async Task<IList<View_EntradaItens>> ListByTransaction(string idTransaction)
        {
            return await _repository.ListByTransaction(idTransaction);
        }
    }
}