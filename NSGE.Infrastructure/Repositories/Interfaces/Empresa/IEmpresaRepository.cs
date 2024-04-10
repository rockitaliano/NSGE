using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IEmpresaRepository
    {
        IList<Empresa> GetAll();
        int Delete(string id);
        Empresa Load(string id);
        Empresa Update(Empresa empresa);
    }
}