using NSGE.CrosCutting.Enum;

namespace NSGE.Domain.Entity.Security
{
    public class Permissao
    {
        public FuncionalidadeEnum Funcionalidade { get; set; }

        public List<PermissaoEnum> Permissoes { get; set; }

        public Permissao()
        {
            Permissoes = new List<PermissaoEnum>();
        }
    }
}