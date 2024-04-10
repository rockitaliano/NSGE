using NSGE.Domain.Entity.Operacional;

namespace NSGE.Services.Interfaces.OrdemServico
{
    public interface IObservacaoOrdemServicoService
    {
        ObservacaoOrdemServico CarregarPorOrdemServico(string idOrdemServico);
    }
}