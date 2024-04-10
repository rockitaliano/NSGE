using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IVeiculoRepository
    {
        IList<Veiculo> Load();
        Veiculo Insert(Veiculo veiculo);
        bool Exists(string id, bool result);
        IList<Veiculo> Filter(Veiculo model);
        Veiculo Pesquisar(Veiculo model);
    }
}
