using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces.Financeiro;
using NSGE.Services.Interfaces.Financeiro;
using NSGE.Services.LinqExtensions;
using System.Linq.Expressions;

namespace NSGE.Services.Services.Financeiro
{
    public class FaturamentoService : IFaturamentoService
    {
        private readonly IFaturamentoRepository _repository;
        public FaturamentoService(IFaturamentoRepository repository)
        {
            _repository = repository;
        }
        public IList<Faturamento> Filtrar(Faturamento filtro = null)
        {
            return _repository.Filtrar(filtro);
        }

        public IList<Pessoa> ListarPorTipo(TipoFuncaoPessoaEnum tipo, Expression<Func<Pessoa, bool>> filtro = null)
        {
            var query = _repository.ListarPorTipo(tipo, filtro);

            if (filtro != null)
                query = query.Where(filtro);

            query = query.WhereTipo(tipo);

            return query.OrderBy(x => x.Nome).ToList();
        }

        public IList<FaturamentoEvento> RetornarFaturamentoEvento(string IdEvento)
        {
            var faturamentoEvento = _repository.RetornarFaturamentoEvento(IdEvento);
            return faturamentoEvento;
        }
    }
}