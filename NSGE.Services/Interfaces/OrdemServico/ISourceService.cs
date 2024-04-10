using Microsoft.AspNetCore.Mvc.Rendering;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface ISourceService
    {
        SelectList Combo(TipoTelaEnum tela, TipoCampoEnum campo);
        IList<Source> GetSources();
        Source LoadId(string id);
        void Delete(string id);
        Source Update(Source source);
    }
}