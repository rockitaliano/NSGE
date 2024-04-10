using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;
        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public Veiculo Insert(Veiculo veiculo)
        {
            return _repository.Insert(veiculo);
        }

        public IList<Veiculo> Load()
        {
            return _repository.Load();
        }

        public bool Exists(string id, bool result)
        {
            return _repository.Exists(id, result);
        }

        public IList<Veiculo> Filter(Veiculo model)
        {
            return _repository.Filter(model);
        }

        public Veiculo Pesquisar(Veiculo model)
        {
            return _repository.Pesquisar(model);
        }
    }
}
