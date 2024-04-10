using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IMarcaRepository
    {
        Marca ObterMarca(string id);
        IList<Marca> List();
        void Update(Marca marca);
        void Insert(Marca marca);
        IEnumerable<Marca> Filtrar(string descricao);
    }
}
