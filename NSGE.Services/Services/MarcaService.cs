using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _repository;
        public MarcaService(IMarcaRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Marca> Filtrar(string descricao)
        {
            throw new NotImplementedException();
        }

        public void Insert(Marca marca)
        {
            throw new NotImplementedException();
        }

        public IList<Marca> List()
        {
            return _repository.List();
        }

        public Marca ObterMarca(string id)
        {
            return _repository.ObterMarca(id);
        }

        public void Update(Marca marca)
        {
            throw new NotImplementedException();
        }
    }
}
