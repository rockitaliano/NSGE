using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public void Delete(string id)
        {
            _statusRepository.Delete(id);
        }

        public IList<Status> Load()
        {
            return _statusRepository.Load();
        }

        public Status LoadId(string id)
        {
            return _statusRepository.LoadId(id);
        }

        public Status Update(Status model)
        {
            return _statusRepository.Update(model);
        }
    }
}