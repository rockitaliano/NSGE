using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IContasAPagarRepository
    {
        public List<ContasAPagar> Filtrar(ContasAPagarFiltro filtro);
        public List<Empresa> List();
        public IList<PlanoDeContas> ListPlanoContas();
        public IList<CentroDeCusto> ListCentroCusto();

        public ContasAPagar GetBaixarId(string id);
        public IList<Status> ListarStatusPorTipo(TipoStatusEnum tipo);
    }
}