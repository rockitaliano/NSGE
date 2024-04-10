using NSGE.Domain.Entity.Almoxarifado;

namespace NSGE.Infrastructure.Repositories.Interfaces.Salario
{
    public interface ISalarioRepository
    {
        public IList<FuncionarioSalario> GetAll();
        public FuncionarioSalario GetById(string id);
        public Task<FuncionarioSalario> Insert(FuncionarioSalario salario);
        public Task<(int rowsAffected, FuncionarioSalario)> Update(FuncionarioSalario salario);
        public Task<int> Delete(string id);

    }
}