using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _repository;
        public DepartamentoService(IDepartamentoRepository repository)
        {
            _repository = repository;
        }

        public Departamento Create(Departamento model)
        {
            return _repository.Create(model);
        }

        public int Delete(string id)
        {
            return _repository.Delete(id);
        }

        public IList<Departamento> List()
        {
            return _repository.List();
        }

        public Departamento LoadId(string id)
        {
            return _repository.LoadId(id);
        }

        public Departamento Update(Departamento model)
        {
            return _repository.Update(model);
        }
    }
}