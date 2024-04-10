using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;
        public EmpresaService(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        public int Delete(string id)
        {
            return _repository.Delete(id);
        }

        public IList<Empresa> GetAll()
        {
            return _repository.GetAll();
        }

        public Empresa Load(string id)
        {
            return _repository.Load(id);
        }

        public Empresa Update(Empresa empresa)
        {
            return _repository.Update(empresa);
        }
    }
}