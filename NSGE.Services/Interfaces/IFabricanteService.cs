using NSGE.Domain.Entity.Almoxarifado;
using NSGE.Domain.Entity.Fabricante;
using NSGE.Domain.Entity.Financeiro;

namespace NSGE.Services.Interfaces
{
    public interface IFabricanteService
    {
        public IList<Fabricante> GetAllFabricantes();
        public IEnumerable<Fabricante> Pesquisar(string value);
        
    }
}