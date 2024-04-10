using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces.OrdemServico;

namespace NSGE.Services.Services.OrdemServico
{
    public class ObservacaoOrdemServicoVersaoService : IObservacaoOrdemServicoVersaoService
    {
        private readonly IObservacaoOrdemServicoVersaoRepository _ordemServicoVersaoRepository;
        public ObservacaoOrdemServicoVersaoService(IObservacaoOrdemServicoVersaoRepository observacaoOrdemServicoVersaoRepository)
        {
            _ordemServicoVersaoRepository = observacaoOrdemServicoVersaoRepository;
        }
        public int GetVersao(string idOrdemServico)
        {
            return _ordemServicoVersaoRepository.GetVersao(idOrdemServico);
        }
    }
}