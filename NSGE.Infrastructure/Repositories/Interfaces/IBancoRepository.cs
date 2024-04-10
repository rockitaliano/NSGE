using NSGE.Domain.Entity.Financeiro;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IBancoRepository
    {
        public IEnumerable<Banco> ListarBancos();
        public IEnumerable<Banco> Pesquisar(string value);
    }
}