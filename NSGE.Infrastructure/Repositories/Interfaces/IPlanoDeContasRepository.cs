using NSGE.Domain.Dtos;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Financeiro;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IPlanoDeContasRepository
    {
        public IEnumerable<ContasAReceber> Filtrar(int? page, ContasAReceberFiltro filtro);
        public IList<PlanoDeContas> TreeView();
        public PlanoDeContas Load(string id);
        public List<CentroDeCusto> ListarCentroDeCusto();
        

    }
}