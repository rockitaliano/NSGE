using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Security;

namespace NSGE.Services.Interfaces.Security
{
    public interface IUsuarioService
    {
        void Logar(string login, string senha);

        void Insert(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(Usuario usuario);

        Usuario Load(string id);

        IList<Usuario> List();

        void Delete(string id);

        void Exist(Usuario usuario, bool update = false);

        void RecriarRelacionamento(Usuario usuario);

        void ExcluirTodosRelacionamentos(Usuario usuario);

        void InserirRelacionamentos(Usuario usuario);

        void TemPerfilAssociado(Usuario model);

        List<Permissao> RecuperarPermissoes(Usuario item);
        public int Count();
        IList<UsuarioPerfil> GetPerfisDoUsuario(string usuarioId);
    }
}