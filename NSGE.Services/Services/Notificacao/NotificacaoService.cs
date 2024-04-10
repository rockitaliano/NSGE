using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly INotificacaoRepository _repository;
        public NotificacaoService(INotificacaoRepository repositoty)
        {
            _repository = repositoty;
        }
        public bool Delete(string id)
        {
            return _repository.Delete(id);
        }

        public IList<Notificacao> Filtrar(string nome, string tipo)
        {
            return _repository.Filtrar(nome, tipo);
        }

        public bool Insert(Notificacao model)
        {
            return _repository.Insert(model);
        }

        public Notificacao Load(string id)
        {
            return _repository.Load(id);
        }

        public bool Update(Notificacao model)
        {
            return _repository.Update(model);
        }
    }
}
