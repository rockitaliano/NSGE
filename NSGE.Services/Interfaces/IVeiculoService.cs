using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IVeiculoService
    {
        IList<Veiculo> Load();
        Veiculo Insert(Veiculo veiculo);
        bool Exists(string id, bool result);
        IList<Veiculo> Filter(Veiculo model);
        Veiculo Pesquisar(Veiculo model);
    }
}
