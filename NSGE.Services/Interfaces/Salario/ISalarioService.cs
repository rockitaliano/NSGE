using NSGE.Domain.Entity.Almoxarifado;

namespace NSGE.Services.Interfaces.Salario
{
    public interface ISalarioService
    {
        public IList<FuncionarioSalario> GetAll();
        public FuncionarioSalario GetById(string id);
        public Task<FuncionarioSalario> Insert(FuncionarioSalario salario);
        public Task<(int rowsAffected, FuncionarioSalario)> Update(FuncionarioSalario funcionario);
        public Task<int> Delete(string id);
    }
}