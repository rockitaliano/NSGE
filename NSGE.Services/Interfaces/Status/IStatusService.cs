using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IStatusService
    {
        IList<Status> Load();
        Status LoadId(string id);
        void Delete(string id);
        Status Update(Status model);
    }
}