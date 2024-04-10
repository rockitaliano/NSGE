using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class RamoAtuacaoService : IRamoAtuacaoService
    {
        private readonly IRamoAtuacaoRepository _repository;
        public RamoAtuacaoService(IRamoAtuacaoRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<RamoAtuacao> Filtrar()
        {
            string nome = "";            
            return _repository.Filtrar().Where(x=> x.Nome.Trim().ToLower().StartsWith(nome.ToLower().Trim()));            
        }
    }
}