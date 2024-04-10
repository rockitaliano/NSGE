using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services.OrdemServico
{
    public class ItemSublocacaoOrdemServicoVersaoService : IItemSublocacaoOrdemServicoVersaoService
    {
        private readonly IItemSublocacaoOrdemServicoVersaoRepository _repository;
        public ItemSublocacaoOrdemServicoVersaoService(IItemSublocacaoOrdemServicoVersaoRepository repository)
        {
            _repository = repository;
        }
        public int GetVersao(string idOrdemServico)
        {
            return _repository.GetVersao(idOrdemServico);
        }
    }
}