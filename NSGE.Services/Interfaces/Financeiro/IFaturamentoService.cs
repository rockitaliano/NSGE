using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;
using System.Linq.Expressions;

namespace NSGE.Services.Interfaces.Financeiro
{
    public interface IFaturamentoService
    {
        public IList<Faturamento> Filtrar(Faturamento filtro = null);
        public IList<Pessoa> ListarPorTipo(TipoFuncaoPessoaEnum tipo, Expression<Func<Pessoa, bool>> filtro = null);
        public IList<FaturamentoEvento> RetornarFaturamentoEvento(string IdEvento);
    }
}