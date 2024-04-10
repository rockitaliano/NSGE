using Microsoft.AspNetCore.Mvc.Rendering;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class SourceService : ISourceService
    {
        private readonly IServiceSourceRepository _serviceSourceRepository;
        public SourceService(IServiceSourceRepository serviceSourceRepository)
        {
            _serviceSourceRepository = serviceSourceRepository;
        }
        public SelectList Combo(TipoTelaEnum tela, TipoCampoEnum campo)
        {
            var telaValue = tela.EnumValue();
            var campoValue = campo.EnumValue();

            var list = _serviceSourceRepository.ListarSource(tela, campo).ToList();
            return new SelectList(list.Where(x => x.Tela == telaValue && x.Campo == campoValue).OrderBy(x => x.Text).ToList());
        }

        public void Delete(string id)
        {
            _serviceSourceRepository.Delete(id);
        }

        public IList<Source> GetSources()
        {
            return _serviceSourceRepository.GetSources();
        }

        public Source LoadId(string id)
        {
            return _serviceSourceRepository.LoadId(id);
        }

        public Source Update(Source source)
        {
            return _serviceSourceRepository.Update(source);
        }
    }
}