using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        IList<Status> Load();
        Status LoadId(string id);
        void Delete(string id);
        Status Update(Status model);
    }
}