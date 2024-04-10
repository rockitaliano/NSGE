namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IObservacaoOrdemServicoVersaoRepository
    {
        int GetVersao(string idOrdemServico);
    }
}