using NSGE.Domain.Entity.Fabricante;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IFabricanteRepository
    {
        public IList<Fabricante> GetAllFabricantes();
        public IEnumerable<Fabricante> Pesquisar(string value);
        //public Task<Fabricante> GetFabricante(string name);
    }
}