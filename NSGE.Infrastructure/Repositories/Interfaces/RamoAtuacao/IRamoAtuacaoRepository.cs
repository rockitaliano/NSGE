using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IRamoAtuacaoRepository
    {
        IEnumerable<RamoAtuacao> Filtrar();
    }
}