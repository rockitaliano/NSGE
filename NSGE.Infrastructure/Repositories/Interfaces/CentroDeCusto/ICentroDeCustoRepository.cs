using NSGE.Domain.Entity;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface ICentroDeCustoRepository
    {
        public IEnumerable<CentroDeCusto> Grid(CentroDeCusto filtro);

        public void Insert(CentroDeCusto item);

        public void Update(CentroDeCusto item);

        public void Delete(string id);

        public bool Existe(CentroDeCusto item);

        public CentroDeCusto GetById(string id);
    }
}