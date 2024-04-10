using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IDepartamentoService
    {
        public IList<Departamento> List();
        Departamento Update(Departamento model);
        int Delete(string id);
        Departamento Create(Departamento model);
        Departamento LoadId(string id);
    }
}