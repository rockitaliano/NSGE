using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        public void Update(Contato item);
        public Contato Load(string id);
    }
}