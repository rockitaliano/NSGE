using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos.CheckList;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity.CheckList;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.CheckList;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class CheckListRepository : ICheckListRepository
    {
        private readonly IDapperContext _context;
        private readonly CheckListSQLContainer _container = new CheckListSQLContainer();

        public CheckListRepository(IDapperContext context)
        {
            _context = context;
        }

        public int BuscarQuantidadeItem(string os, string itemId)
        {
            var query = _container.GetQuantity();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (os != null)
                    parameters.Add("@NumeroOs", os, DbType.String);

                if (itemId != null)
                    parameters.Add("@ItemId", itemId, DbType.String);

                var result = connection.Query<int>(query, parameters);

                return result.ToList().Count;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public EventoDto CarregarOS(string numeroDaOS)
        {
            var result = new EventoDto();
            var query = _container.CarregarOS();
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            try
            {
                parameters.Add("@NumeroOs", numeroDaOS, DbType.String);

                result = connection.QuerySingleOrDefault<EventoDto>(query, parameters);

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public string CarregarResponsavel(string numeroDaOS)
        {
            var query = _container.CarregarResponsavel();

            using var connection = _context.CreateConnection();

            var parameter = new DynamicParameters();
            query = query.Replace("@NumeroDaOs", numeroDaOS);
            parameter.Add("@NumeroDaOs", numeroDaOS, DbType.String);

            var resultOs = connection.Query<dynamic>(query, parameter);

            return resultOs.ToString();
        }

        public IList<string> ContatosDoEvento(string numeroDaOS)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id, int result)
        {
            var queryArquivo = _container.DeleteArquivo();
            var queryAgendatecnica = _container.DeleteAgendaTecnica();
            var queryEvento = _container.Delete();
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();

            queryArquivo += " AND EventoId = @Id";
            parameters.Add("Id", id, DbType.String);
            connection.Execute(queryArquivo, parameters);

            queryAgendatecnica += " AND EventoId = @Id";
            connection.Execute(queryAgendatecnica, parameters);

            queryEvento += " AND Id = @Id";

            connection.Execute(queryEvento, parameters);

            var count = connection.Query("SELECT ROW_COUNT() AS linhas_excluidas;");

            return (Task)count;
        }

        public bool Existe(string numeroDaOS)
        {
            var query = _container.Exist();
            var parameter = new DynamicParameters();

            try
            {
                parameter.Add("@NumeroOs", numeroDaOS, DbType.String);

                using var connection = _context.CreateConnection();
                bool result = connection.QuerySingleOrDefault<bool>(query, parameter);

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public async Task<IList<CheckListGrid>> GetAllOs()
        {
            var query = _container.GetCheckList();

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<CheckListGrid>(query);
                return result.ToList();
            }
        }

        public async Task<IList<CheckListGrid>> GetByOs(CheckListGrid numeroOs)
        {
            var query = _container.GetCheckListByOS();
            try
            {
                var parameters = new DynamicParameters();
                using var connection = _context.CreateConnection();

                if (numeroOs.NumeroDaOs != null)
                {
                    query += " AND E.NumeroDaOS = @NumeroDaOs";
                    parameters.Add("@NumeroDaOS", numeroOs.NumeroDaOs.Trim(), DbType.String);
                }

                var resultOs = await connection.QueryAsync<CheckListGrid>(query, parameters);

                return resultOs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<ItemChecklist> ListarFilhos(string parentId)
        {
            var query = _container.ListarFilhos();
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@item", parentId, DbType.String);
                using var connection = _context.CreateConnection();

                var result = connection.Query<ItemChecklist>(query, parameter);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<ItemChecklist> ListarPais()
        {
            var query = _container.ListarPais();
            using var connection = _context.CreateConnection();

            var result = connection.Query<ItemChecklist>(query);

            return result.ToList();
        }

        public ChecklistExtra LoadPorOS(string numeroDaOS)
        {
            var query = _container.LoadOs();
            var parameters = new DynamicParameters();
            try
            {
                //query += query.Replace("@NumeroOs", numeroDaOS);
                parameters.Add("@NumeroOs", numeroDaOS, DbType.String);

                using var connection = _context.CreateConnection();
                var result = connection.QueryFirstOrDefault<ChecklistExtra>(query, parameters);

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<string> OperadoresPorOS(string numeroDaOS)
        {
            var Tipo = TipoFuncaoPessoaEnum.Tecnico.GetEnumValue();
            var query = _container.OperadoresPorOs();
            var parameters = new DynamicParameters();
            using var connections = _context.CreateConnection();
            try
            {
                parameters.Add("@Tipo", Tipo, DbType.String);
                parameters.Add("@NumeroOS", numeroDaOS, DbType.String);

                var result = connections.Query<string>(query, parameters);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public int RecuperarVersao(string numeroDaOS)
        {
            throw new NotImplementedException();
        }

        public bool TemFilhos(string parentId)
        {
            var query = _container.TemFilhos();

            var parameter = new DynamicParameters();
            using var connection = _context.CreateConnection();

            if (parentId != null)
            {                
                parameter.Add("@ParentId", parentId, DbType.String);

                var result = connection.Query(query, parameter);

                if (result != null)
                    return true;
            }

            return false;
        }
    }
}