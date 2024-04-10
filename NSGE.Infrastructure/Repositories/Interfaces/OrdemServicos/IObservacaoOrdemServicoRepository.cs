using NSGE.Domain.Entity.Operacional;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IObservacaoOrdemServicoRepository
    {
        ObservacaoOrdemServico CarregarPorOrdemServico(string idOrdemServico);
    }
}