using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NSGE.Domain.Entity.Associative;

namespace NSGE.Domain.Entity.Security
{
    public class Usuario : EntityBase
    {
       
        public string Nome { get; set; }
       
        public string Login { get; set; }
        
        public string Senha { get; set; }
        
        public string Email { get; set; }
        
        public bool Status { get; set; }

        [Display(Name = "Recebe email")]
        public bool RecebeEmail { get; set; }

        public bool Administrador { get; set; }

        public string Imagem { get; set; }

        public IList<UsuarioPerfil> Perfis { get; set; }

        public DateTime DataDoCadastro { get; set; }
        public DateTime? DataDeAlteracao { get; set; }

        [NotMapped]
        public string PrimeiroNome
        {
            get { return Nome.Split()[0]; }
        }

        [NotMapped]
        public string SenhaOriginal { get; set; }

        [NotMapped]
        public bool SenhaFoiAlterada
        {
            get
            {
                return Senha != SenhaOriginal;
            }
        }

        [NotMapped]
        public bool Bloqueado { get; set; }

        [NotMapped]
        [Display(Name = "Status")]
        public string StatusDescricao { 
            get {
                var statusEnum = Status ? "Ativo" : "Inativo";
                return statusEnum;
            } 
        }

        public Usuario()
        {
            Perfis = new List<UsuarioPerfil>();
        }
    }
}