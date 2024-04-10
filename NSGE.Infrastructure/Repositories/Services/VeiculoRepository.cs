using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGEInfrastructureSQLBuilderVeiculo;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly IDapperContext _context;
        private readonly VeiculoSQLContainer _container;
        public VeiculoRepository(IDapperContext context, VeiculoSQLContainer container)
        {
            _context = context;
            _container = container;

        }

        public bool Exists(string id, bool result)
        {
            var query = _container.Exists();
            //bool result;
            try
            {
                using var connection = _context.CreateConnection();                

                var idResult = connection.ExecuteScalar<string>(query, new { Id = id });

                result = !string.IsNullOrEmpty(idResult); // Se o resultado não for nulo ou vazio, então o registro existe

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<Veiculo> Filter(Veiculo model)
        {

            var query = _container.FilterParameter();
            var parameter = new DynamicParameters();
            var result = new List<Veiculo>();
            model.Descricao = model.MarcaDescricao;
            try
            {
                //if (model.Marca.Descricao != null)
                //    parameter.Add("@Marca", model.Marca.Descricao, DbType.String);

                //if (model.Modelo != null)
                //    parameter.Add("@Modelo", model.Modelo, DbType.String);

                //if (model.Placa != null)
                //    parameter.Add("@Placa", model.Placa, DbType.String);

                using var connection = _context.CreateConnection();
                result = connection.Query<Veiculo>(query, model).ToList();

                return result;               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Veiculo Insert(Veiculo veiculo)
        {
            var query = _container.Insert();
            var parameter = new DynamicParameters();
            try
            {
                if (veiculo != null)
                {
                    parameter.Add("@Id", Guid.NewGuid(), DbType.String);
                    parameter.Add("@MarcaId", veiculo.MarcaId, DbType.String);
                    parameter.Add("@Modelo", veiculo.Modelo, DbType.String);
                    parameter.Add("@Placa", veiculo.Placa, DbType.String);
                    parameter.Add("@Descricao", veiculo.Descricao, DbType.String);
                    parameter.Add("@AnoDeFabricacao", veiculo.AnoDeFabricacao, DbType.String);
                    parameter.Add("@AnoDoModelo", veiculo.AnoDoModelo, DbType.String);
                    parameter.Add("@Cor", veiculo.Cor, DbType.String);
                }
                using var _connection = _context.CreateConnection();
                _connection.Execute(query, parameter);
                return veiculo;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<Veiculo> Load()
        {
            var query = _container.Load();
            try
            {
                using var _connection = _context.CreateConnection();
                var result = _connection.Query<Veiculo>(query).ToList();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Veiculo Pesquisar(Veiculo model)
        {
            var query = _container.Filter();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<Veiculo>(query, model).FirstOrDefault();
                
                return result;
            }
            catch (Exception ex)
            {
                throw new NSGECustomException("", ex.Message);
            }
        }
    }
}
