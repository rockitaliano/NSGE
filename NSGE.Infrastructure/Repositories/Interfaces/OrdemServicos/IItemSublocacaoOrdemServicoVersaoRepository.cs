namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IItemSublocacaoOrdemServicoVersaoRepository
    {
        int GetVersao(string idOrdemServico);
    }
}