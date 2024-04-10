using NSGE.Infrastructure.Context.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;

using MySql.Data.MySqlClient;

namespace NSGE.Infrastructure.Context
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _iConfiguration;
        private readonly string _connString;
        public DapperContext (IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
            _connString = _iConfiguration.GetConnectionString("WebApiDatabase");
        }
        public IDbConnection CreateConnection() => new MySqlConnection(_connString);
    }
}
