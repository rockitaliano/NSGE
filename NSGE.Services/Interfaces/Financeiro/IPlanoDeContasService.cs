using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IPlanoDeContasService
    {
        public IEnumerable<ContasAReceber> Filtrar(int? page, ContasAReceberFiltro filtro);

        public List<Status> ListarPorTipo(TipoStatusEnum tipo);

        IList<Empresa> List();

        public IList<PlanoDeContas> ListPlanoContas();

        public IList<PlanoDeContas> TreeView();

        public PlanoDeContas InstanciarPlanoDeContas(string parentId);

        public IList<CentroDeCusto> ListCentroCusto();
        public PlanoDeContas Load(string id);
    }
}