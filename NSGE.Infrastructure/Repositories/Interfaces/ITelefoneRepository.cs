using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface ITelefoneRepository
    {
        public void ExcluirPorContato(string contatoId);
        public void Insert(IList<Telefone> list);
    }
}