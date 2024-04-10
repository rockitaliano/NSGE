using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Contato;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly IDapperContext _context;
        private readonly ContatoSQLContainer _container;

        public ContatoRepository(IDapperContext context, ContatoSQLContainer container)
        {
            _context = context;
            _container = container;
        }

        public Contato Load(string id)
        {
            var query = _container.Load();
            var parameter = new DynamicParameters();
            dynamic result = "";
            try
            {
                if(id != null)
                {
                    parameter.Add("@Id", id, DbType.String);
                    using var connection = _context.CreateConnection();
                    result = connection.Query<Contato>(query, parameter).FirstOrDefault();
                                        
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Update(Contato item)
        {
            var query = _container.Update();
            var parameter = new DynamicParameters();

            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}