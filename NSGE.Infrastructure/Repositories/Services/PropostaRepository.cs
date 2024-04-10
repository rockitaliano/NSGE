using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Propostas;
using NSGE.Domain.Entity.Propostas.Dtos;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Proposta;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly IDapperContext _context;
        private PropostaSQLContainer _propostaContainer = new PropostaSQLContainer();

        public PropostaRepository(IDapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public IList<Status> ListarPorTipo(string tipo)
        {
            var sql = _propostaContainer.ListarPorTipo();
            string tipoString = tipo.ToString();

            using var connection = _context.CreateConnection();
            sql = sql.Replace("{WHERE}", tipoString);
            var result = connection.Query<Status>(sql);
            return result.ToList();
        }

        public async Task<IList<StatusPropostaDTO>> ListarPorStatus(string tipo)
        {
            var query = _propostaContainer.GetTipoStatus();
            try
            {
                using var connection = _context.CreateConnection();
                query = query.Replace("{WHERE}", tipo);
                var result = await connection.QueryAsync<StatusPropostaDTO>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public async Task<IList<Proposta>> GetPropostasAsync(PropostaFiltro filtro = null)
        {
            var query = _propostaContainer.QueryPropostasParameters();
            try
            {
                using var connection = _context.CreateConnection();
                var propostas = await connection.QueryAsync<Proposta>(query);
                return propostas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<Pessoa> ListarVendedor(TipoFuncaoPessoaEnum tipoFuncao, string nome = null)
        {
            var query = _propostaContainer.ListaVendedores();
            using var connection = _context.CreateConnection();
            var vendedores = connection.Query<Pessoa>(query);
            return vendedores.ToList();
        }

        public Proposta Edit(Proposta model)
        {
            var query = "UPDATE Proposta SET ";

            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (model != null)
                {
                    if (model.NumeroDaProposta != null)
                    {
                        query += "NumeroDaProposta = @NumeroDaProposta, ";
                        parameters.Add("@NumeroDaProposta", model.NumeroDaProposta, DbType.Int32);
                    }

                    if (model.Cliente != null)
                    {
                        query += "Cliente = @Cliente, ";
                        parameters.Add("@Cliente", model.Cliente, DbType.String);
                    }

                    if (model.Evento != null)
                    {
                        query += "Evento = @Evento, ";
                        parameters.Add("@Evento", model.Evento, DbType.String);
                    }

                    if (model.Data != null)
                    {
                        query += "Data = @Data, ";
                        parameters.Add("@Data", model.Data, DbType.Date);
                    }

                    if (model.DataDoEvento != null)
                    {
                        query += "DataDoEvento = @DataDoEvento, ";
                        parameters.Add("@DataDoEvento", model.DataDoEvento, DbType.Date);
                    }

                    if (model.Equipamento != null)
                    {
                        query += "Equipamento = @Equipamento, ";
                        parameters.Add("@Equipamento", model.Equipamento, DbType.String);
                    }

                    if (model.IdDoFuncionario != null)
                    {
                        query += "IdDoFuncionario = IdDoFuncionario, ";
                        parameters.Add("@IdDoFuncionario", model.IdDoFuncionario, DbType.String);
                    }

                    if (model.ValorTotal != null)
                    {
                        query += "ValorTotal = @ValorTotal";
                        parameters.Add("@ValorTotal", model.ValorTotal, DbType.Decimal);
                    }

                    if (model.UltimaRevisao != null)
                    {
                        query += "UltimaRevisao = @UltimaRevisao, ";
                        parameters.Add("@UltimaRevisao", model.UltimaRevisao, DbType.Double);
                    }

                    if (model.NomeDoContato != null)
                    {
                        query += "NomeDoContato = @NomeDoContato, ";
                        parameters.Add("@NomeDoContato", model.NomeDoContato, DbType.String);
                    }

                    if (model.DDD != null)
                    {
                        query += "DDD = @DDD, ";
                        parameters.Add("@DDD", model.DDD, DbType.String);
                    }

                    if (model.Numero != null)
                    {
                        query += "Numero = @Numero, ";
                        parameters.Add("@Numero", model.Numero, DbType.String);
                    }

                    if (model.Email != null)
                    {
                        query += "Email = @Email, ";
                        parameters.Add("@Email", model.Email, DbType.String);
                    }

                    if (model.IdStatus != null)
                    {
                        query += "IdStatus = @IdStatus, ";
                        parameters.Add("@IdStatus", model.IdStatus, DbType.String);
                    }

                    if (model.Observacao != null)
                    {
                        query += "Observacao = @Observacao, ";
                        parameters.Add("@Observacao", model.Observacao, DbType.String);
                    }

                    query += "MalaDireta = @MalaDireta, ";
                    parameters.Add("@MalaDireta", model.MalaDireta, DbType.Boolean);

                    query = query.TrimEnd(',', ' ');

                    if (model.Id != null)
                    {
                        query += " Where Id = @Id";
                        parameters.Add("@Id", model.Id, DbType.String);
                    }

                    var result = connection.Execute(query, parameters);

                    if (result > 0)
                    {
                        var update = RecuperarPorId(model.Id);
                        return update;
                    }
                    else
                        throw new NSGECustomException("Falha na atualização de Entidade.");
                }
                else
                    throw new NSGECustomException("O modelo de proposta é nulo.");
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public async Task<int> Add(Proposta proposta)
        {
            string ultimoNumeroProposta = _propostaContainer.GetLastProposal();
            var query = _propostaContainer.AddProposta();

            using var connection = _context.CreateConnection();

            int ultimoNumero = await connection.ExecuteScalarAsync<int>(ultimoNumeroProposta, null);
            int novoNumero = ultimoNumero + 1;
            proposta.NumeroDaProposta = novoNumero;

            Guid novoGuid = Guid.NewGuid();
            var novo = novoGuid.ToString().Substring(0, 32);
            proposta.Id = novo.ToString();

            var parameters = new DynamicParameters();
            parameters.Add("Id", proposta.Id, DbType.String);
            parameters.Add("NumeroDaProposta", proposta.NumeroDaProposta, DbType.Int32);
            parameters.Add("Data", proposta.Data, DbType.Date);
            parameters.Add("Cliente", proposta.Cliente, DbType.String);
            parameters.Add("IdDoFuncionario", proposta.IdDoFuncionario, DbType.String);
            parameters.Add("IdStatus", proposta.IdStatus, DbType.String);
            parameters.Add("Equipamento", proposta.Equipamento, DbType.String);
            parameters.Add("Evento", proposta.Evento, DbType.String);
            parameters.Add("DataDoEvento", proposta.DataDoEvento, DbType.Date);
            parameters.Add("ValorTotal", proposta.ValorTotal, DbType.Double);
            parameters.Add("UltimaRevisao", proposta.UltimaRevisao, DbType.Double);
            parameters.Add("NomeDoContato", proposta.NomeDoContato, DbType.String);
            parameters.Add("DDD", proposta.DDD, DbType.String);
            parameters.Add("Numero", proposta.Numero, DbType.String);
            parameters.Add("Email", proposta.Email, DbType.String);
            parameters.Add("Observacao", proposta.Observacao, DbType.String);
            parameters.Add("MalaDireta", proposta.MalaDireta, DbType.Boolean);

            try
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return novoNumero;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public async Task<IList<Proposta>> GetPropostasByFilterAsync(PropostaFiltro filtro)
        {
            var query = _propostaContainer.QueryPropostasByParameters();
            try
            {
                using var connection = _context.CreateConnection();
                var queryParameters = new DynamicParameters();
                if (filtro != null)
                {
                    if (filtro.InicioEvento.HasValue)
                    {
                        query += " AND PR.DataDoEvento >= @DataInicial";
                        queryParameters.Add("@DataInicial", filtro.InicioEvento.Value, DbType.DateTime);
                    }

                    if (filtro.FimEvento.HasValue)
                    {
                        query += " AND PR.DataDoEvento <= @DataFinal";
                        queryParameters.Add("@DataFinal", filtro.FimEvento.Value, DbType.DateTime);
                    }

                    if (!string.IsNullOrEmpty(filtro.IdStatus))
                    {
                        query += " AND PR.IdStatus = @IdStatus";
                        queryParameters.Add("@IdStatus", filtro.IdStatus, DbType.String);
                    }

                    if (!string.IsNullOrEmpty(filtro.IdDoFuncionario))
                    {
                        query += " AND PR.IdDoFuncionario = @Vendedor";
                        queryParameters.Add("@Vendedor", filtro.IdDoFuncionario, DbType.String);
                    }

                    if (!string.IsNullOrEmpty(filtro.Evento))
                    {
                        query += " AND PR.Evento LIKE @Evento";
                        queryParameters.Add("@Evento", $"%{filtro.Evento}%", DbType.String);
                    }

                    if (!string.IsNullOrEmpty(filtro.Cliente))
                    {
                        query += " AND PR.Cliente LIKE @Cliente";
                        queryParameters.Add("@Cliente", $"%{filtro.Cliente}%", DbType.String);
                    }

                    if (filtro.NumeroDaProposta > 0)
                    {
                        query += " AND PR.NumeroDaProposta = @NumeroDaProposta";
                        queryParameters.Add("@NumeroDaProposta", filtro.NumeroDaProposta, DbType.Int32);
                    }

                    if (filtro.Valor.HasValue)
                    {
                        query += " AND PR.ValorTotal = @Valor";
                        queryParameters.Add("@Valor", filtro.Valor, DbType.Decimal);
                    }

                    if (filtro.StatusProposta.HasValue)
                    {
                        query += " AND PR.StatusProposta = @StatusProposta";
                        queryParameters.Add("@StatusProposta", filtro.StatusProposta.Value, DbType.Int32);
                    }
                }
                var propostas = await connection.QueryAsync<Proposta>(query, queryParameters);

                return propostas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public Proposta AlterarStatus(Proposta model)
        {
            var query = _propostaContainer.Load();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                parameters.Add("@Id", model.IdStatus, DbType.String);

                var result = connection.Query<Proposta>(query, parameters).FirstOrDefault();

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public int Update(Proposta model)
        {
            var query = _propostaContainer.Update();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (model != null)
                {
                    if (model.Id != null)
                        parameters.Add("@Id", model.Id, DbType.String);
                    if (model.Cliente != null)
                        parameters.Add("@Cliente", model.Cliente, DbType.String);
                    if (model.Evento != null)
                        parameters.Add("@Evento", model.Evento, DbType.String);
                    if (model.Data != null)
                        parameters.Add("@Data", model.Data, DbType.Date);
                    if (model.DataDoEvento != null)
                        parameters.Add("@DataDoEvento", model.DataDoEvento, DbType.Date);
                    if (model.Equipamento != null)
                        parameters.Add("@Equipamento", model.Equipamento, DbType.String);
                    if (model.IdDoFuncionario != null)
                        parameters.Add("@IdDoFuncionario", model.IdDoFuncionario, DbType.String);
                    if (model.ValorTotal != null)
                        parameters.Add("@ValorTotal", model.ValorTotal, DbType.Double);
                    if (model.UltimaRevisao != null)
                        parameters.Add("@UltimaRevisao", model.UltimaRevisao, DbType.Double);
                    if (model.NomeDoContato != null)
                        parameters.Add("@NomeDoContato", model.NomeDoContato, DbType.String);
                    if (model.DDD != null)
                        parameters.Add("@DDD", model.DDD, DbType.String);
                    if (model.Numero != null)
                        parameters.Add("@Numero", model.Numero, DbType.String);
                    if (model.Email != null)
                        parameters.Add("@Email", model.Email, DbType.String);
                    if (model.IdStatus != null)
                        parameters.Add("@IdStatus", model.IdStatus, DbType.String);
                    if (model.Observacao != null)
                        parameters.Add("@Observacao", model.Observacao, DbType.String);

                    parameters.Add("@NumeroProposta", model.NumeroDaProposta, DbType.Int32);

                    parameters.Add("@MalaDireta", model.MalaDireta, DbType.Boolean);

                    var result = connection.Execute(query, parameters);

                    return result;
                }
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
            return 0;
        }

        public Proposta RecuperarPorId(string id)
        {
            var query = _propostaContainer.Load();
            var parameter = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                parameter.Add("@Id", id, DbType.String);
                var result = connection.Query<Proposta>(query, parameter).FirstOrDefault();

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public int Delete(string id)
        {
            var query = _propostaContainer.Delete();
            var parameter = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                parameter.Add("@Id", id, DbType.String);
                var result = connection.Execute(query, parameter);

                if (result > 0)
                {
                    return result;
                }
                else
                    throw new NSGECustomException("Falha na atualização de Entidade.");
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}