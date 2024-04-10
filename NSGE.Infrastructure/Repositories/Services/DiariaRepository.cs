using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Agenda;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.DiariaTecnica;
using System.Data;
using System.Globalization;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class DiariaRepository : IDiariaRepository
    {
        private readonly IDapperContext _context;
        private DiariaSQLContainer _container = new DiariaSQLContainer();

        public DiariaRepository(IDapperContext context)
        {
            _context = context;
        }

        public void AtualizarValores(IList<TecnicoDia> list)
        {
            var query = _container.Update();
            var parameter = new DynamicParameters();
            var lista = new List<TecnicoDia>();
            foreach (var item in list)
            {
                parameter.Add("@Id", item.Id, DbType.String);
                parameter.Add("@AgendaId", item.AgendaId, DbType.String);
                parameter.Add("@TecnicoId", item.TecnicoId, DbType.String);
                parameter.Add("@Tipo", item.Tipo, DbType.Int16);
                parameter.Add("@ValorDiaria", item.ValorDiaria, DbType.Double);
                parameter.Add("@ValorAlimentacao", item.ValorAlimentacao, DbType.Double);
                parameter.Add("@Diaria", item.DiariaPG, DbType.Boolean);
                parameter.Add("@Alimentacao", item.AlimentacaoPG, DbType.Boolean);

                try
                {
                    using var connection = _context.CreateConnection();
                    var update = connection.Execute(query, parameter);
                }
                catch (NSGECustomException ex)
                {
                    throw new Exception("" + ex.Message);
                }
            }
        }

        public async Task<IList<DiariaTecnicaGrid>> GetDiariaFiltro(DiariaTecnicaFiltro filtro)
        {
            var model = new List<DiariaTecnicaGrid>();
            model.Select(x => x.Equals(filtro));

            var query = _container.QueryDiariasParameters();
            try
            {
                using var connection = _context.CreateConnection();
                var queryParameters = new DynamicParameters();
                if (filtro != null)
                {
                    if (filtro.DataInicio.HasValue)
                    {
                        query += " AND DataEvento >= @DataInicial";
                        queryParameters.Add("@DataInicial", filtro.DataInicio.Value, DbType.DateTime);
                    }

                    if (filtro.DataFinal.HasValue)
                    {
                        query += " AND DataEvento <= @DataFinal";
                        queryParameters.Add("@DataFinal", filtro.DataFinal.Value, DbType.DateTime);
                    }

                    if (!string.IsNullOrEmpty(filtro.Tecnico))
                    {
                        query += " AND Tecnico LIKE @Nome";
                        queryParameters.Add("@Nome", "%" + filtro.Tecnico + "%", DbType.String);
                    }

                    if (filtro.Tipo.HasValue)
                    {
                        query += " AND Tipo = @Tipo";
                        queryParameters.Add("@Tipo", filtro.Tipo, DbType.Int16);
                    }
                }
                var diaria = await connection.QueryAsync<DiariaTecnicaGrid>(query, queryParameters);

                return diaria.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public async Task<IList<DiariaTecnicaGrid>> GetDiarias()
        {
            var sql = _container.GetDiarias();
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<DiariaTecnicaGrid>(sql);
                result = result.ToList().GroupBy(x => x.TecnicoId).Select(x => new DiariaTecnicaGrid
                {
                    TecnicoId = x.Key,
                    Tecnico = x.First().Tecnico,
                    TotalDiaria = x.Sum(y => y.ValorDiaria).ToString("C2", CultureInfo.CreateSpecificCulture("pt-br")),
                    TotalAlimentacao = x.Sum(y => y.ValorAlimentacao).ToString("C2", CultureInfo.CreateSpecificCulture("pt-br"))
                }).OrderBy(x => x.Tecnico).AsQueryable();

                return result.ToList();
            }
        }

        public IList<DiariaTecnica> ListarPorTecnico(string tecnicoId)
        {
            var query = _container.ListarPorTecnicoEdit();
            var parameter = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (tecnicoId != null)
                    parameter.Add("@TecnicoId", tecnicoId, DbType.String);

                var result = connection.Query<DiariaTecnica>(query, parameter);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public DiariaTecnica Pesquisar(string tecnico, DateTime? dataInicial, DateTime? dataFinal, TipoFuncaoPessoaEnum tipo)
        {
            var query = _container.QueryDiariasParameters();
            var parameter = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (tecnico != null)
                    parameter.Add("@Tecnico", tecnico, DbType.String);
                if (dataInicial != null)
                    parameter.Add("@DataInicial", dataInicial, DbType.Date);
                if (dataFinal != null)
                    parameter.Add("@DataFinal", dataFinal, DbType.Date);
                if (tipo != null)
                    parameter.Add("@Tipo", tipo, DbType.String);

                var result = connection.Query<DiariaTecnica>(query, parameter).FirstOrDefault();

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}