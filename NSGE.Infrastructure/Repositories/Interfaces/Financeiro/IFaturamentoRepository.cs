using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;
using System.Linq.Expressions;

namespace NSGE.Infrastructure.Repositories.Interfaces.Financeiro
{
    public interface IFaturamentoRepository
    {
        public IList<Faturamento> Filtrar(Faturamento filtro);
        public IQueryable<Pessoa> ListarPorTipo(TipoFuncaoPessoaEnum tipo, Expression<Func<Pessoa, bool>> filtro = null);
        public IList<FaturamentoEvento> RetornarFaturamentoEvento(string IdEvento);
    }
}