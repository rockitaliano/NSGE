using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Security
{
    public class PerfilFuncionalidadeAcesso : EntityBase
    {
        public string? PerfilId { get; set; }
        public string? FuncionalidadeId { get; set; }
        public string? AcessoId { get; set; }

        [ForeignKey("PerfilId")]
        public Perfil? Perfil { get; set; }

        [ForeignKey("FuncionalidadeId")]
        public virtual Funcionalidade? Funcionalidade { get; set; }

        [ForeignKey("AcessoId")]
        public virtual Acesso? Acesso { get; set; }
    }
}