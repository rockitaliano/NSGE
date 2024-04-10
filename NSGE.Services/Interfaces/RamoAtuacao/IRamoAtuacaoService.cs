using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IRamoAtuacaoService
    {
        IEnumerable<RamoAtuacao> Filtrar();
    }
}