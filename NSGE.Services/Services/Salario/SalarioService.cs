using NSGE.Domain.Entity.Almoxarifado;
using NSGE.Infrastructure.Repositories.Interfaces.Salario;
using NSGE.Services.Interfaces.Salario;

namespace NSGE.Services.Services.Salario
{
    public class SalarioService : ISalarioService
    {
        private readonly ISalarioRepository _repository;
        public SalarioService(ISalarioRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Delete(string id)
        {
           return _repository.Delete(id);
        }

        public IList<FuncionarioSalario> GetAll()
        {
            return _repository.GetAll();
        }

        public FuncionarioSalario GetById(string id)
        {
            return _repository.GetById(id);
        }

        public Task<FuncionarioSalario> Insert(FuncionarioSalario salario)
        {
            return _repository.Insert(salario);
        }

        public Task<(int rowsAffected, FuncionarioSalario)> Update(FuncionarioSalario salario)
        {
            return _repository.Update(salario);
        }
    }
}