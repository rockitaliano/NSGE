using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface INotificacaoService
    {
        IList<Notificacao> Filtrar(string nome, string tipo);
        bool Delete(string id);
        bool Update(Notificacao model);
        bool Insert(Notificacao model);
        Notificacao Load(string id);
    }
}
