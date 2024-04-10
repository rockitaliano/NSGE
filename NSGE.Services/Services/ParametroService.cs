using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class ParametroService : IParametroService
    {
        private readonly IParametroRepository _repository;
        public ParametroService(IParametroRepository repository)
        {
            _repository = repository;
        }

        public string CarregarPorNome(ParametroEnum key)
        {
            var chave = key.EnumValue();
            var parametro = _repository.Filter(chave); //.Where(x => x.key == chave).FirstOrDefault();
            
            return parametro != null ? parametro.Value : "";
        }

        public string Filter(ParametroEnum key)
        {
            var chave = key.GetEnumValue();

            var parametro = _repository.Filter(chave);
            

            return parametro != null ? parametro.Value : "";
        }
    }
}