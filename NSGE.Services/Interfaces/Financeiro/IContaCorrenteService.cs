using NSGE.Domain.Entity.Financeiro;

namespace NSGE.Services.Interfaces.Financeiro
{
    public interface IContaCorrenteService
    {
        public IList<Banco> PesquisarBancosPorEmpresa(string idEmpresa);

        public IList<ContaCorrente> PesquisarPorEmpresaEBanco(string idEmpresa, string idBanco);

        public IList<ContaCorrente> GetAll();
    }
}