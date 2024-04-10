using NSGE.Domain.Entity.Financeiro;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IContaCorrenteRepository
    {
        public IList<Banco> PesquisarBancosPorEmpresa(string idEmpresa);

        public IList<ContaCorrente> PesquisarPorEmpresaEBanco(string idEmpresa, string idBanco);

        public IList<ContaCorrente> GetAll();
    }
}