using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IServiceSourceRepository
    {
        List<Source> ListarSource(TipoTelaEnum tela, TipoCampoEnum campo);
        IList<Source> GetSources();
        Source LoadId(string id);
        void Delete(string id);
        Source Update(Source source);
    }
}