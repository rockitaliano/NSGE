using NSGE.Domain.Entity.Financeiro;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _repository;
        public BancoService(IBancoRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Banco> ListarBancos()
        {
            return _repository.ListarBancos();
        }

        public IEnumerable<Banco> Pesquisar(string value)
        {
            return _repository.Pesquisar(value);
        }
    }
}