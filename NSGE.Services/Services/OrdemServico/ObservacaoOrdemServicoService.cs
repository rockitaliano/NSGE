using NSGE.Domain.Entity.Operacional;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces.OrdemServico;

namespace NSGE.Services.Services.OrdemServico
{
    public class ObservacaoOrdemServicoService : IObservacaoOrdemServicoService
    {
        private readonly IObservacaoOrdemServicoRepository _repository;
        public ObservacaoOrdemServicoService(IObservacaoOrdemServicoRepository repository)
        {
            _repository = repository;
        }
        public ObservacaoOrdemServico CarregarPorOrdemServico(string idOrdemServico)
        {
            return _repository.CarregarPorOrdemServico(idOrdemServico);
        }
    }
}