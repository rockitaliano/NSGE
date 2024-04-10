using NSGE.Domain.Entity.Operacional;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IOrdemServicoRepository
    {
        IList<ItemOrdemServicoVersao> ListOSServicoVersao();

        IList<ItemSublocacaoOrdemServicoVersao> ListItemSubLocacaoServicoVersao();

        OrdemServico Load(string id);
    }
}