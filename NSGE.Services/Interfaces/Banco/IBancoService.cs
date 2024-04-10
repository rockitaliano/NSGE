using NSGE.Domain.Entity.Financeiro;

namespace NSGE.Services.Interfaces
{
    public interface IBancoService
    {
        public IEnumerable<Banco> ListarBancos();
        public IEnumerable<Banco> Pesquisar(string value);
    }
}
