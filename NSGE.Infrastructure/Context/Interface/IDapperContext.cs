using System.Data;


namespace NSGE.Infrastructure.Context.Interface
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
