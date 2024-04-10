using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Associative
{
    public class UsuarioPerfil : EntityBase
    {        
        public string? UsuarioId { get; set; }
        public string? PerfilId { get; set; }

        //[ForeignKey("UsuarioId")]
        //public Usuario? Usuario { get; set; }

        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        //[ForeignKey("PerfilId")]
        public Perfil? Perfil { get; set; }
    }

}