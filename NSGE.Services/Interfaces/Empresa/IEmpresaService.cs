using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IEmpresaService
    {
        IList<Empresa> GetAll();
        int Delete(string id);
        Empresa Load(string id);
        Empresa Update(Empresa empresa);
    }
}