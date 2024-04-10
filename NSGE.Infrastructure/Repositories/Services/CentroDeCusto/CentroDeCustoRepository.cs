using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.CentroDeCusto;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class CentroDeCustoRepository : ICentroDeCustoRepository
    {
        private IDapperContext _context;
        private readonly CentroDeCustoSQLContainer _container;

        public CentroDeCustoRepository(IDapperContext context, CentroDeCustoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public IEnumerable<CentroDeCusto> Grid(CentroDeCusto filtro)
        {
            var query = _container.GetCentroDeCusto();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<CentroDeCusto>(query).ToList();

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public void Insert(CentroDeCusto item)
        {
            var query = _container.Insert();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (item.Descricao != null)
                    parameters.Add("Descricao", item.Descricao, DbType.String);

                if (item.Codigo != null)
                    parameters.Add("@Codigo", item.Codigo, DbType.Int32);

                if (item.ExibirEmContasAReceber == true)
                    parameters.Add("@ExibirEmContasAReceber", item.ExibirEmContasAReceber, DbType.Boolean);
                else
                    item.ExibirEmContasAReceber = false;

                if (item.ExibirEmContasAPagar == true)
                    parameters.Add("@ExibirEmContasAPagar", item.ExibirEmContasAPagar, DbType.Boolean);
                else
                    item.ExibirEmContasAPagar = false;

                connection.Execute(query, parameters);
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public void Update(CentroDeCusto item)
        {
            var query = _container.Update();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (item.Descricao != null)
                    parameters.Add("Descricao", item.Descricao, DbType.String);

                if (item.Codigo != null)
                    parameters.Add("@Codigo", item.Codigo, DbType.Int32);

                if (item.ExibirEmContasAReceber == true)
                    parameters.Add("@ExibirEmContasAReceber", item.ExibirEmContasAReceber, DbType.Boolean);
                else
                    item.ExibirEmContasAReceber = false;

                if (item.ExibirEmContasAPagar == true)
                    parameters.Add("@ExibirEmContasAPagar", item.ExibirEmContasAPagar, DbType.Boolean);
                else
                    item.ExibirEmContasAPagar = false;

                connection.Execute(query, parameters);
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public void Delete(string id)
        {
            var query = _container.Delete();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (id != null)
                    parameters.Add("@Id", id, DbType.String);

                connection.Execute(query, parameters);
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public bool Existe(CentroDeCusto item)
        {
            var query = _container.Existe();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();

                if (item.Descricao != null)
                    parameters.Add("@Descricao", item.Descricao, DbType.String);

                if (item.Codigo != null)
                    parameters.Add("@Codigo", item.Codigo, DbType.Int32);

                var result = connection.Query(query, parameters);

                return result != null;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public CentroDeCusto GetById(string id)
        {
            var query = _container.GetCentroDeCustoById();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (id != null)
                    parameters.Add("@Id", id, DbType.String);

                var result = connection.Query<CentroDeCusto>(query, parameters).FirstOrDefault();

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}