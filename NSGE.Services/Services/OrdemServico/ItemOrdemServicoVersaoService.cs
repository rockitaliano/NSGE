using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces.OrdemServico;

namespace NSGE.Services.Services.OrdemServico
{
    public class ItemOrdemServicoVersaoService : IItemOrdemServicoVersaoService
    {
        private readonly IItemOrdemServicoVersaoRepository _itemOrdemServicoVersaoRepository;
        public ItemOrdemServicoVersaoService(IItemOrdemServicoVersaoRepository itemOrdemServicoVersaoRepository)
        {
            _itemOrdemServicoVersaoRepository = itemOrdemServicoVersaoRepository;
        }
        public int GetVersao(string idOrdemServico)
        {
            try
            {
                return _itemOrdemServicoVersaoRepository.GetVersao(idOrdemServico);                
            }
            catch 
            {
                return 0;
            }
        }
    }
}