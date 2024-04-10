using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Clientes;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Listas;
using NSGE.Infrastructure.SQLBuilder.Pessoa;
using System.Data;
using System.Text;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IDapperContext _context;
        private readonly ListasSQLContainer _lista;
        private readonly ClientesSQLContainer _clientes;

        public PessoaRepository(IDapperContext context, ListasSQLContainer lista, ClientesSQLContainer clientes)
        {
            _context = context;
            _lista = lista;
            _clientes = clientes;
        }

        public Task Create(Pessoa _Branch)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            var query = _clientes.GetClientes();
            //var query = "SELECT * FROM " + typeof(Pessoa).Name;
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<Pessoa>(query);
            return result;
        }

        public async Task<Pessoa> GetByIdAsync(string id)
        {
            var sbWhere = new StringBuilder();
            sbWhere?.AppendFormat(String.Join(" ", id));

            var query = _clientes.GetPessoasPorId().Replace(" {WHERE} ", sbWhere.ToString()); //$"SELECT * FROM { typeof(Pessoa).Name.ToLower()}  WHERE Id = @id".ToLower();

            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstAsync<Pessoa>(query);
            return result;
        }

        public async Task<Pessoa> Pesquisa(Pessoa pessoa)
        {
            var query = _clientes.Pesquisa();
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            if (pessoa != null)
            {
                if (pessoa.NomeFantasia != null)
                {
                    query += " AND P.NomeFantasia =  @NomeFantasia";
                    parameters.Add("@NomeFantasia", pessoa.NomeFantasia, DbType.String);
                }
                if (pessoa.Nome != null)
                {
                    query += " AND P.Nome = @Nome";
                    parameters.Add("@Nome", pessoa.Nome, DbType.String);
                }
                if (pessoa.Documento != null)
                {
                    query += " AND LENGTH(P.Documento = @Documento) = 11";
                    parameters.Add("@Documento", pessoa.Documento, DbType.String);
                }
                if (pessoa.Status != null)
                {
                    query += " AND S.IdStatus = @IdStatus";
                    parameters.Add("@IdStatus", pessoa.IdStatus, DbType.String);
                }
            }
            return null;
        }

        public IEnumerable<Qualificacao> GetQualificacao()
        {
            var query = _lista.GetQualificacao();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Qualificacao>(query);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IEnumerable<RamoAtuacao> GetRamoAtuacao()
        {
            var query = _lista.GetRamoAtuacao();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<RamoAtuacao>(query);
                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public async Task<RamoAtuacao> GetRamoAtuacaoByIdAsync(string id)
        {
            string query = "SELECT * FROM RamoAtuacao WHERE Id = @Id";

            var parameters = new { Id = id };
            using var connection = _context.CreateConnection();
            var ramoAtuacao = await connection.QueryFirstOrDefaultAsync<RamoAtuacao>(query, parameters);

            return ramoAtuacao;
        }

        public IList<Pessoa> ListByType(Pessoa tipoStatus)
        {
            var enumV = tipoStatus.TesteTipoStatus.GetEnumValue();
            string query = "SELECT Id, Descricao, TipoDoCadastro, Leitura FROM Status WHERE TipoDoCadastro = @EnumV ORDER BY Descricao ASC";

            var parameters = new { EnumV = enumV };
            using var connection = _context.CreateConnection();
            var result = connection.Query<Pessoa>(query, parameters).ToList();
            return result;
        }

        public Task Update(Pessoa _Branch)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PessoaFiltro>> Pesquisar(PessoaFiltro model)
        {
            var query = _clientes.Pesquisa();
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            if (model != null)
            {
                if (model.Nome != null)
                {
                    query += " AND P.Nome LIKE @Nome";
                    parameters.Add("@Nome", $"%{model.Nome}%", DbType.String);
                }
                if (model.Documento != null && model.Documento.Length <= 11)
                {
                    query += " AND P.Documento LIKE @Documento";
                    parameters.Add("@Documento", $"%{model.Documento}%", DbType.String);
                }
                if (model.Status != null)
                {
                    query += " AND S.Id = @IdStatus";
                    parameters.Add("@IdStatus", model.IdStatus, DbType.String);
                }
                //if (model.rec != null)
                //{
                //    query += " AND P.Cliente = @Funcao OR P.Produtor = @Funcao OR P.Fornecedor = @Funcao OR P.Funcionario = @Funcao OR P.Freelancer = @Funcao OR P.Transportadora = @Funcao " +
                //        "OR P.Motorista = @Funcao OR P.Tecnico = @Funcao OR P.RepresentanteComercial = @Funcao OR P.Almoxarife = @Funcao OR P.Sublocacao = @Funcao";
                //    parameters.Add("@Funcao", model.ListaFuncoes, DbType.String);
                //}
                if (model.RamoAtuacaoId != null)
                {
                    query += " AND RA.Id = @RamoAtuacaoId";
                    parameters.Add("@RamoAtuacaoId", model.RamoAtuacaoId, DbType.String);
                }
                if (model.QualificacaoId != null)
                {
                    query += " AND QA.Id = @QualificacaoId";
                    parameters.Add("@QualificacaoId", model.QualificacaoId, DbType.String);
                }

                query += " GROUP BY\r\n P.NomeFantasia,\r\n    " +
                    "P.Nome,\r\n    P.Documento,\r\n    " +
                    "CONCAT(P.Nome, ' : ', '(', T.DDD, ')', T.Numero),\r\n    " +
                    "S.Id,\r\n   " +
                    "S.Descricao";
            }
            try
            {
                var result = connection.Query<PessoaFiltro>(query, parameters);

                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public List<Pessoa> Filtro(PessoaFiltro model)
        {
            var query = _clientes.Pesquisa();
            try
            {
                return null;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public Pessoa RetornarPessoa(string idPessoa)
        {
            var query = _clientes.RetornarPessoa();
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@Id", idPessoa, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Pessoa>(query, parameters).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public Pessoa Load(string id)
        {
            var query = _clientes.Load();
            var parameters = new DynamicParameters();

            try
            {
                parameters.Add("@Id", id, DbType.String);
                using var connection = _context.CreateConnection();
                var result = connection.Query<Pessoa>(query, parameters).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IQueryable<Pessoa> Filter()
        {
            var query = _clientes.Filter();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = connection.Query<Pessoa>(query).AsQueryable();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<Pessoa> ListarRepresentanteComercial()
        {
            var query = _clientes.Listar();

            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Pessoa>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}