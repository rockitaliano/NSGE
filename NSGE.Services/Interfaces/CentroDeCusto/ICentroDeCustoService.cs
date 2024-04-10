using NSGE.Domain.Entity;

namespace NSGE.Services.Interfaces
{
    public interface ICentroDeCustoService
    {
        public IEnumerable<CentroDeCusto> Grid(CentroDeCusto filtro);

        public void Insert(CentroDeCusto item);

        public void Update(CentroDeCusto item);

        public void Delete(string id);

        public bool Existe(CentroDeCusto item);

        public CentroDeCusto GetById(string id);
    }
}