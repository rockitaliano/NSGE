using Dapper;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.SQLBuilder.Telefone;
using System.Data;

namespace NSGE.Infrastructure.Repositories.ImplementRepository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private IDapperContext _context;
        private readonly TelefoneSQLContainer _container;
        public TelefoneRepository(IDapperContext context, TelefoneSQLContainer container)
        {
            _context = context;
            _container = container;

        }
        public void ExcluirPorContato(string contatoId)
        {
            var query = _container.ExcluirPorContato();
            var parameter = new DynamicParameters();

            try
            {
                if(contatoId != null)
                {
                    parameter.Add("@ContatoId", contatoId, DbType.String);
                    using (var connection = _context.CreateConnection())
                    {
                        connection.Execute(query, parameter);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert(IList<Telefone> list)
        {
            var query = _container.Insert();
            var parameter = new DynamicParameters();

            try
            {
                if(list != null)
                {
                    foreach (var item in list)
                    {
                        using var connection = _context.CreateConnection();
                        parameter.Add("@List", item, DbType.String);
                        connection.Execute(query, parameter);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}