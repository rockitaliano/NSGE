using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services
{
    public class ContasAPagarService : IContasAPagarService
    {
        private readonly IContasAPagarRepository _repository;
        public ContasAPagarService(IContasAPagarRepository repository)
        {
            _repository = repository;
        }
        public List<ContasAPagar> Filtrar(ContasAPagarFiltro filtro)
        {
            return _repository.Filtrar(filtro);
        }

        public ContasAPagar GetBaixarId(string id)
        {
            return _repository.GetBaixarId(id);
        }

        public IList<Empresa> List()
        {
            return _repository.List();
        }

        public IList<Status> ListarStatusPorTipo(TipoStatusEnum tipo)
        {
            return _repository.ListarStatusPorTipo(tipo);
        }

        public IList<CentroDeCusto> ListCentroCusto()
        {
            return _repository.ListCentroCusto();
        }

        public IList<PlanoDeContas> ListPlanoContas()
        {
            return _repository.ListPlanoContas();
        }
    }
}