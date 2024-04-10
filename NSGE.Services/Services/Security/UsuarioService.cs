using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Security;
using NSGE.Infrastructure.Repositories.Interfaces.Usuarios;
using NSGE.Services.Interfaces.Security;

namespace NSGE.Services.Services.Security
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        //private readonly SistemaService _sistemaService;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            //_sistemaService = sistemaService;
        }

        public int Count()
        {
            return 0; // _repository.Count();
        }

        public void Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void ExcluirTodosRelacionamentos(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Exist(Usuario usuario, bool update = false)
        {
            throw new NotImplementedException();
        }

        public IList<UsuarioPerfil> GetPerfisDoUsuario(string usuarioId)
        {
            var usuarioPerfil = _usuarioRepository.GetPerfisDoUsuario(usuarioId);

            return usuarioPerfil.ToList();
            
        }

        public void InserirRelacionamentos(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Insert(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> List()
        {
            return _usuarioRepository.List();
        }

        public Usuario Load(string id)
        {
            var usuario = new Usuario();
            usuario = _usuarioRepository.Load(id);
            return usuario;
        }

        public void Logar(string login, string senha)
        {
            //if (!_sistemaService.ValidarSerial())
            //    throw new NSGECustomException("Sua licença expirou, por favor entre em contato com o administrador do sistema.");

            //login = login.ToLower();

            //var user = _usuarioRepository.Filter(login).Where(x => x.Login.ToLower().Equals(login) || x.Email.ToLower().Equals(login)).FirstOrDefault();

            //if (user == null || !user.Senha.CompararPassword(senha))
            //    throw new NSGECustomException(MessageValidate.ExceptionLoginInvalido);

            //// Coloco as permissões do usuario na session
            //SessionService.Permissoes = RecuperarPermissoes(user);

            //// limpo os perfis antes de colocar o usuario na sessão para otimizar memoria
            //user.Perfis.Clear();
            //// Coloco usuario na session
            //SessionService.UsuarioLogado = user;
        }

        public void RecriarRelacionamento(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Permissao> RecuperarPermissoes(Usuario item)
        {
            throw new NotImplementedException();
        }

        public void TemPerfilAssociado(Usuario model)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}