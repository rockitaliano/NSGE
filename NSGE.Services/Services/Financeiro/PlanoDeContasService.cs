using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;
using NSGE.Services.Interfaces.Financeiro;
using System.Linq.Expressions;

namespace NSGE.Services
{
    public class PlanoDeContasService : IPlanoDeContasService
    {
        private readonly IContasAReceberRepository _contasRepository;
        private readonly IPlanoDeContasRepository _repository;
        private readonly IContasAPagarService _empresas;
        public PlanoDeContasService(IPlanoDeContasRepository repository, IContasAPagarService empresas, IContasAReceberRepository contasRepository)
        {
            _repository = repository;
            _empresas = empresas;
            _contasRepository = contasRepository;
        }
        public IEnumerable<ContasAReceber> Filtrar(int? page, ContasAReceberFiltro filtro)
        {
            throw new NotImplementedException();
        }

        public PlanoDeContas InstanciarPlanoDeContas(string parentId)
        {
            throw new NotImplementedException();
        }

        public IList<PlanoDeContas> List(Expression<Func<PlanoDeContas, bool>> lambda)
        {
            throw new NotImplementedException();
        }

        public IList<Empresa> List()
        {
            return _empresas.List();
        }

        public List<Status> ListarPorTipo(TipoStatusEnum tipo)
        {
            var enumValue = tipo.GetEnumValue();
            return _contasRepository.ListarPorTipo(enumValue);
        }

        public IList<CentroDeCusto> ListCentroCusto()
        {
            return _repository.ListarCentroDeCusto();
        }

        public IList<PlanoDeContas> ListPlanoContas()
        {
            return _repository.TreeView();
        }

        public PlanoDeContas Load(string id)
        {
            return _repository.Load(id);
        }

        public IList<PlanoDeContas> TreeView()
        {
            var treeviewList = _repository.TreeView();
            treeviewList.OrderBy(x => x.Id)
                .Select(x => new ItemTreeView(x.Id, x.ContaSintetica, string.Format("{0} - {1}", x.Id, x.NomeDaConta)))
                .ToList();

            return treeviewList;
        }

        private bool Existe(PlanoDeContas item, bool isUpdate = false)
        {
            //var query = _repository.Filter().Where(x =>
            //    x.NomeDaConta.ToLower() == item.NomeDaConta.ToLower() ||
            //    x.CodigoContabil == item.CodigoContabil ||
            //    x.Reduzido == item.Reduzido);

            //if (isUpdate)
            //    query = query.Where(x => x.Id != item.Id);
            var query = "";

            return query.Any();
        }        
    }
}