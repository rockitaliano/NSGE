using NSGE.Domain.Entity.Security;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository _repository;
        public PerfilService(IPerfilRepository repository)
        {
            _repository = repository;
        }

        public IList<Perfil> Filtrar(string nome)
        {
            return _repository.Filtrar(nome);
        }

        public IList<Perfil> ListarIgnorandoPerfisDoUsuario(Usuario user)
        {
            var perfil = _repository.Listar(user);
            if (user != null)
            {
                
                var perfisDoUsuario = user.Perfis.Select(x => x.PerfilId).ToList();
                HashSet<string> conjunto = new HashSet<string>(perfisDoUsuario);

                perfil = perfil.Where(x => !conjunto.Contains(x.Id)).ToList();
            }

            return perfil.OrderBy(x => x.Nome).ToList();
        }

        public IList<Perfil> Load()
        {
            return _repository.Load();
        }

        public Perfil LoadForId(string id)
        {
            return _repository.LoadForId(id);
        }
    }
}