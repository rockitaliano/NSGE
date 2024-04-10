using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IMarcaService
    {
        Marca ObterMarca(string id);

        IList<Marca> List();

        void Update(Marca marca);

        void Insert(Marca marca);

        IEnumerable<Marca> Filtrar(string descricao);
    }
}