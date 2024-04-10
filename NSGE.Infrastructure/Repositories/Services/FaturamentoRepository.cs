using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces.Financeiro;
using NSGE.Infrastructure.SQLBuilder.Faturamento;
using System.Data;
using System.Linq.Expressions;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class FaturamentoRepository : IFaturamentoRepository
    {
        private readonly IDapperContext _context;
        private readonly FaturamentoSQLContainer _container;

        public FaturamentoRepository(IDapperContext context, FaturamentoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IList<Faturamento> Filtrar(Faturamento filtro)
        {
            var query = _container.Filtrar();
            var parameter = new DynamicParameters();

            try
            {
                if (filtro != null)
                {
                    if (filtro.DataDeEmissao != null)
                    {
                        //query = query.Replace("{WHERE}", tipo);
                        query += " AND Extent1.DataDeEmissao = @DataDeEmissao";
                        parameter.Add("@DataDeEmissao", filtro.DataDeEmissao, DbType.DateTime);
                    }

                    if (!string.IsNullOrEmpty(filtro.NumeroDaNotaFiscal))
                    {
                        query += " AND Extent1.NumeroDaNotaFiscal = @NumeroDaNotaFiscal";
                        parameter.Add("@NumeroDaNotaFiscal", filtro.NumeroDaNotaFiscal, DbType.String);
                    }

                    if (!string.IsNullOrEmpty(filtro.IdDoCliente))
                    {
                        query += " AND Extent1.IdDoCliente = @IdDoCliente";
                        parameter.Add("@IdDoCliente", filtro.IdDoCliente, DbType.String);
                    }

                    if (!string.IsNullOrEmpty(filtro.IdDoFuncionario))
                    {
                        query += " AND Extent1.IdDoFuncionario = @IdDoFuncionario";
                        parameter.Add("@IdDoFuncionario", filtro.IdDoFuncionario, DbType.String);
                    }

                    if (!string.IsNullOrEmpty(filtro.Id))
                    {
                        query += " AND Extent1.Id = @Id";
                        parameter.Add("@Id", filtro.Id, DbType.String);
                    }
                }

                using var connection = _context.CreateConnection();

                var result = connection.Query<Faturamento>(query, parameter);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IQueryable<Pessoa> ListarPorTipo(TipoFuncaoPessoaEnum tipo, Expression<Func<Pessoa, bool>> filtro = null)
        {
            var query = _container.GetPessoa();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@Dynamic", filtro.Name, DbType.String);
                parameters.Add("@Dynamic2", filtro.Name, DbType.String);

                using var connection = _context.CreateConnection();
                var result = connection.Query<Pessoa>(query, parameters);

                return (IQueryable<Pessoa>)result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<FaturamentoEvento> RetornarFaturamentoEvento(string IdEvento)
        {
            var query = _container.RetornarFaturamentoEvento();
            var parameters = new DynamicParameters();

            try
            {
                parameters.Add("@EventoId", IdEvento, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<FaturamentoEvento>(query, parameters).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}