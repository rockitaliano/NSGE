using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Entity.Security
{
    public class Perfil : EntityBase
    {
        //[Required(ErrorMessageResourceName = "Required")]
        //[StringLength(30, ErrorMessageResourceName = "StringLength")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        //[Required(ErrorMessageResourceName = "Required")]
        //[StringLength(50, ErrorMessageResourceName = "StringLength")]
        public string Descricao { get; set; }

        public virtual IList<PerfilFuncionalidadeAcesso> Funcionalidades { get; set; }

        public Perfil()
        {
            Funcionalidades = new List<PerfilFuncionalidadeAcesso>();
        }
    }
}