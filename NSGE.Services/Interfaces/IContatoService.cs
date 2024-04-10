using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IContatoService
    {
        public void Update(Contato item);
        public Contato Load(string id);
    }
}