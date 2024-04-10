using Dapper;
using NSGE.Domain.Entity.Almoxarifado;
using NSGE.Domain.Entity.Clientes;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces.Almoxarifado;
using NSGE.Infrastructure.SQLBuilder.Almoxarifado;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository.Almoxarifado
{
    public class AlmoxarifadoRepository : IAlmoxarifadoRepository
    {
        private readonly IDapperContext _context;

        private readonly AlmoxarifadoSQLContainer _container;
        public AlmoxarifadoRepository(IDapperContext context, AlmoxarifadoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IList<TipoServico> Dropdown()
        {
            var query = _container.DropDown();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<TipoServico>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro" + ex.Message);
            }
        }

        public IList<Pessoa> DropDownPessoa()
        {
            var query = _container.GetPessoa();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Pessoa>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message);
            }
        }

        public async Task<IList<RegistroViewModel>> FindBy(string pessoaId, string eventoId, DateTime? dataInicio, DateTime? dataFim)
        {
            var query = _container.GetServicoAlmoxarifeRegistro();
            var parameters = new DynamicParameters();
            try
            {
                if(pessoaId != null)
                    parameters.Add("pessoaId", pessoaId, DbType.String);

                if(eventoId != null)
                    parameters.Add("eventoId", eventoId, DbType.String);

                if(dataInicio != null)
                    parameters.Add("dataInicio", dataInicio, DbType.DateTime);

                if(dataFim != null)
                    parameters.Add("dataFim", dataFim, DbType.String);

                using var connection = _context.CreateConnection();
                var result = connection.Query<RegistroViewModel>(query, parameters).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro FindBy" + ex.Message);
            }
        }

        public IList<ServicoAlmoxarifeRegistro> GetAlmoxarifadoAsync()
        {
            var query = _container.GetRegistros();
            
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<ServicoAlmoxarifeRegistro>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro" + ex.Message);
            }
        }

        public async Task<IList<Evento>> GetEventos()
        {
            var query = _container.GetEventos();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Evento>(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro" + ex.Message);
            }
        }

        public async Task<PessoaFiltro> GetNome(string pessoaId)
        {
            var query = _container.GetNome();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@PessoaId", pessoaId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<PessoaFiltro>(query, parameter).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no GetNome" + ex.Message);
            }
        }

        public async Task<IList<Pessoa>> GetPessoas()
        {
            var query = _container.GetPessoas();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Pessoa>(query).ToList();

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro GetPessoas" + ex.Message);
            }
        }

        public async Task<IList<ServicoAlmoxarifeRegistro>> GetRegistros()
        {
            var query = _container.GetRegistros();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<ServicoAlmoxarifeRegistro>(query).ToList();

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro GetRegistros" + ex.Message);
            }

        }

        public async Task<IList<TipoServico>> GetTipoServico()
        {
            var query = _container.GetTipoServico();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<TipoServico>(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro" + ex.Message);
            }
        }

        public async Task<ServicoAlmoxarifeRegistro> Load(string id)
        {
            var query = _container.Load();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<ServicoAlmoxarifeRegistro>(query, parameter).FirstOrDefault();

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro" + ex.Message);
            }
        }

        public async Task<IList<ServicoAlmoxarife>> ServicoAlmoxarife()
        {
            var query = _container.GetServicos();
            
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<ServicoAlmoxarife>(query).ToList();

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro" + ex.Message);
            }
        }

        public Task Update(IEnumerable<ServicoAlmoxarifeRegistro> list)
        {
            var query = _container.Update();
            var parameter = new DynamicParameters();
            dynamic result = null;
            try
            {
                foreach (var item in list)
                {
                    if (item.Id != null)
                        parameter.Add("@Id", item.Id, DbType.String);

                    if (item.ServicoAlmoxarifeId != null)
                        parameter.Add("@ServicoAlmoxarifeId", item.ServicoAlmoxarifeId, DbType.String);

                    if(item.TipoServicoId != null)
                        parameter.Add("@TipoServicoId", item.TipoServicoId, DbType.String);

                    if (item.Data != null)
                        parameter.Add("@Data", item.Data, DbType.DateTime);

                    if(item.DataFim != null)
                        parameter.Add("@DataFim", item.DataFim, DbType.DateTime);

                    if (item.HoraInicio != null)
                        parameter.Add("@HoraInicio", item.HoraInicio, DbType.Time);

                    if(item.HoraFim != null)
                        parameter.Add("@HoraFim", item.HoraFim, DbType.Time);

                    if (item.ValorServico != 0)
                        parameter.Add("@ValorServico", item.ValorServico, DbType.Double);

                    if (item.ValorAlimentacao > 0)
                        parameter.Add("@ValorAlimentacao", item.ValorAlimentacao, DbType.Double);

                    if (item.AlimentacaoPago != false)
                        parameter.Add("@AlimentacaoPago", item.AlimentacaoPago, DbType.Boolean);

                    using var connection = _context.CreateConnection();
                    result = connection.Query(query, parameter).ToList();                   
                }
                return Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Update do repository "+ ex.Message);
            }
        }
    }
}