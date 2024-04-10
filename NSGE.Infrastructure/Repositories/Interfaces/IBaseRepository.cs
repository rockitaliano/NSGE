using NSGE.Domain.Entity.Config;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        IList<Sistema> Filter();
    }
}