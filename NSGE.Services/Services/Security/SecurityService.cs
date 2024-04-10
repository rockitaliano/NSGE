using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Security;
using NSGE.Services.Services.Session;

namespace NSGE.Services.Services.Security
{
    public class SecurityService
    {
        public static bool Autorizado(FuncionalidadeEnum funcionalidade, PermissaoEnum permissao)
        {
            if (!isLogado())
                return false;

            if (isAdministrador())
                return true;

            var permissoes = SessionService.Permissoes;

            var permissaoRequisitada = permissoes.Where(x => x.Funcionalidade == funcionalidade).SingleOrDefault();

            if (permissaoRequisitada == null)
                return false;

            return permissaoRequisitada.Permissoes.Contains(permissao);
        }

        public static bool Autorizado(FuncionalidadeEnum funcionalidade, params PermissaoEnum[] permissoes)
        {
            foreach (var permissao in permissoes)
            {
                if (!Autorizado(funcionalidade, permissao))
                    return false;
            }

            return true;
        }

        public static bool Autorizado(List<FuncionalidadeEnum> funcionalidades)
        {
            if (!isLogado())
                return false;

            if (isAdministrador())
                return true;

            var permissoes = SessionService.Permissoes;

            return permissoes.Any(x => funcionalidades.Contains(x.Funcionalidade));
        }

        public static bool isLogado()
        {
            var user = SessionService.UsuarioLogado;
            return user != null;
        }

        public static bool isAdministrador()
        {
            return SessionService.UsuarioLogado.Administrador;
        }

        public static bool isBloqueado()
        {
            return SessionService.UsuarioLogado.Bloqueado;
        }
    }
}