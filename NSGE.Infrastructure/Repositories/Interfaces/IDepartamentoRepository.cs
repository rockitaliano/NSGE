using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IDepartamentoRepository
    {
        public IList<Departamento> List();
        Departamento Update(Departamento model);
        int Delete(string id);
        Departamento Create(Departamento model);
        Departamento LoadId(string id);

    }
}