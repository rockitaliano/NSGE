using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Messages;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Local;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class LocalRepository : ILocalRepository
    {
        private readonly IDapperContext _context;
        private readonly LocalSQLContainer _container;

        public LocalRepository(IDapperContext context, LocalSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public async Task<IList<Local>> GetAll()
        {
            var sql = _container.GetAll();
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Local>(sql);
                return result.ToList();
            }
        }

        public async Task<IList<Local>> GetByFilter(string descricao)
        {
            var query = _container.GetByFilter();
            var queryAll = _container.GetAll();
            var parameter = new DynamicParameters();
            var result = new List<Local>();

            using (var connection = _context.CreateConnection())
            {
                if (descricao != null)
                {
                    parameter.Add("@Descricao", descricao, DbType.String);
                    result = connection.QueryAsync<Local>(query, parameter).Result.ToList();

                    return result;
                }
                else
                {
                    result = connection.QueryAsync<Local>(queryAll).Result.ToList();
                    return result;
                }                
            }
        }

        public async Task<Local> Load(string id)
        {
            var query = _container.Load();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<Local, EnderecoLocal, Endereco, Local>(query, (local, enderecoLocal, endereco) =>
                {
                    if (local != null)
                    {
                        local.Enderecos ??= new List<EnderecoLocal>();
                        enderecoLocal.Endereco = endereco; // Associando o EnderecoLocal ao Endereco
                        local.Enderecos.Add(enderecoLocal);
                        local.EnderecoLocal.EnderecoId = endereco.Id;                        
                    }
                    return local;
                },
                parameter,
                splitOn: "C2,EnderecoId" // Indicando as colunas para dividir os resultados
                );

                return result.FirstOrDefault();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IEnumerable<Local> FilterWithRelation(string id)
        {
            var local = new Local();
            var parameter = new DynamicParameters();
            var locais = _container.Load();
            parameter.Add("@Id", id, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var result = connection.Query<Local>(locais, parameter);
                foreach (var item in result)
                {
                    local.Enderecos = item.Enderecos.Where(e => e.LocalId == local.Id).ToList();
                }
            }

            return (IEnumerable<Local>)local;
        }

        public void Delete(string id)
        {
            var query = _container.Delete();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                connection.Execute(query, parameter);
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public void Insert(Local entity)
        {
            var query = _container.Insert();
            var parameters = new DynamicParameters();
            try
            {
                if (ExisteLocal(entity))
                {
                    throw new NSGECustomException(MessageValidate.ExceptionLocalDuplicado);
                }
                if (entity.Id != null)
                    parameters.Add("@gp1", entity.Id, DbType.String);

                foreach (var item in entity.Enderecos)
                {
                    if (item.Endereco.CEP != null)
                        parameters.Add("@Cep", item.Endereco.CEP, DbType.String);
                    if (item.Endereco.Logradouro != null)
                        parameters.Add("@Logradouro", item.Endereco.Logradouro, DbType.String);
                    if (item.Endereco.Numero != null)
                        parameters.Add("@Numero", item.Endereco.Numero, DbType.String);
                    if (item.Endereco.Complemento != null)
                        parameters.Add("@Complemento", item.Endereco.Complemento, DbType.String);
                    if (item.Endereco.Bairro != null)
                        parameters.Add("@Bairro", item.Endereco.Bairro, DbType.String);
                    if (item.Endereco.Cidade != null)
                        parameters.Add("@Cidade", item.Endereco.Cidade, DbType.String);
                    if (item.Endereco.UF != null)
                        parameters.Add("@Uf", item.Endereco.UF, DbType.String);
                    if (item.Endereco.Principal)
                        parameters.Add("@Principal", item.Endereco.Principal, DbType.Boolean);
                    if (item.Endereco.Registro)
                        parameters.Add("@Registro", item.Endereco.Registro, DbType.Boolean);
                    if (item.Endereco.Cobranca)
                        parameters.Add("@Cobranca", item.Endereco.Cobranca, DbType.Boolean);
                    if (item.Endereco.Entrega)
                        parameters.Add("@Entrega", item.Endereco.Entrega, DbType.Boolean);
                    if (item.Endereco.Faturamento)
                        parameters.Add("@Faturamento", item.Endereco.Faturamento, DbType.Boolean);
                    if (item.Endereco.Evento)
                        parameters.Add("@Evento", item.Endereco.Evento, DbType.Boolean);
                }

                using var connection = _context.CreateConnection();
                connection.Execute(query, parameters);
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        private bool ExisteLocal(Local model, bool update = false)
        {
            var query = _container.ExisteLocal();
            var parameter = new DynamicParameters();
            try
            {
                parameter.Add("@Descricao", model.Descricao, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Local>(query, parameter);

                result.Where(x => x.Id != model.Id);
                return result.Count() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public Endereco Enderecos(Local local)
        {
            var query = _container.GetEnderecosByParameter();
            var parameter = new DynamicParameters();
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public List<LocalEvento> RecuperarHospedagens(string eventoId)
        {
            var query = _container.RecuperarHospedagens();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@EventoId", eventoId, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<LocalEvento>(query, parameter).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}