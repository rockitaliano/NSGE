using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Operacional;

namespace NSGE.Services.Interfaces
{
    public interface IOrdemServicoService
    {
        IList<ItemOrdemServicoVersao> ListOSServicoVersao();
        IList<ItemSublocacaoOrdemServicoVersao> ListItemSubLocacaoServicoVersao();

        Domain.Entity.Operacional. OrdemServico Load(string id);
        OrdemServicoDadosEvento CarregarDadosEvento(string idDoEvento);
        void SalvarVersaoOSServicoVersoes();
        int GetVersao(string idOrdemServico);

    }
}
