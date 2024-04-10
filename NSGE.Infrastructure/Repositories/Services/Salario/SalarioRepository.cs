using Dapper;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Almoxarifado;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces.Salario;
using NSGE.Infrastructure.SQLBuilder.Salario;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class SalarioRepository : ISalarioRepository
    {
        private IDapperContext _context;
        private SalarioSQLContainer _container;

        public SalarioRepository(IDapperContext context, SalarioSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public async Task<int> Delete(string id)
        {
            var query = _container.Delete();
            var parameter = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (id != null)
                    parameter.Add("@IdFuncionario", id, DbType.String);

                var result = await connection.ExecuteAsync(query, parameter);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public IList<FuncionarioSalario> GetAll()
        {
            var query = _container.GetAll();
            try
            {
                using var connection = _context.CreateConnection();
                var result = connection.Query<FuncionarioSalario>(query);

                return result.ToList();
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public FuncionarioSalario GetById(string id)
        {
            var query = _container.GetById();
            var parameter = new DynamicParameters();

            try
            {
                using var connection = _context.CreateConnection();
                if (id != null)
                    parameter.Add("@Id", id, DbType.String);

                var result = connection.Query<FuncionarioSalario>(query, parameter).FirstOrDefault();

                return result;
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public async Task<FuncionarioSalario> Insert(FuncionarioSalario salario)
        {
            var query = _container.Insert();
            var parameters = new DynamicParameters();

            try
            {
                using var connection = _context.CreateConnection();
                if (salario.Id != null)
                    parameters.Add("@Id", salario.Id, DbType.String);
                if (salario.FuncionarioId != null)
                    parameters.Add("IdFuncionario", salario.FuncionarioId, DbType.String);
                if (salario.Salario != 0)
                    parameters.Add("@Valor", salario.Salario, DbType.Double);

                var result = await connection.ExecuteAsync(query, parameters);

                if (result > 0)
                    return salario;
                else
                    throw new NSGECustomException("Erro ao inserir o salário do funcionário.");
            }
            catch (NSGECustomException ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public async Task<(int rowsAffected, FuncionarioSalario)> Update(FuncionarioSalario salario)
        {
            var query = _container.Update();
            var parameters = new DynamicParameters();
            try
            {
                using var connection = _context.CreateConnection();
                if (salario.Id != null)
                    parameters.Add("@Id", salario.Id, DbType.String);

                if (salario.FuncionarioId != null)
                    parameters.Add("@IdFuncionario", salario.FuncionarioId.ToString(), DbType.String);

                if (salario.Salario != 0)
                    parameters.Add("@Salario", salario.Salario);

                var rowsAffected = await connection.ExecuteAsync(query, parameters);
                if (rowsAffected > 0)
                    return (rowsAffected, salario);
                else
                    throw new NSGECustomException("Erro ao atualizar o salário do funcionário.");
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}