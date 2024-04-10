using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface INotificacaoRepository
    {
        IList<Notificacao> Filtrar(string nome, string tipo);
        bool Delete(string id);
        bool Update(Notificacao model);
        bool Insert(Notificacao model);
        Notificacao Load(string id);
    }
}
