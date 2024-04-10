using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace NSGE.Domain.Models
{
    public class Contato : EntityBase
    {
        [Display(Name = "Departamento")]
        [StringLength(32)]
        public string IdDoDepartamento { get; set; }

        //[Required(ErrorMessageResourceName = "Required")]
        //[StringLength(255, ErrorMessageResourceName = "MaxLength")]
        public string? Nome { get; set; }

        [Display(Name = "Função")]
        [StringLength(40, ErrorMessageResourceName = "MaxLength")]
        public string? Funcao { get; set; }

        [EmailAddress(ErrorMessageResourceName = "EmailAddress", ErrorMessage = null)]
        public string? Email { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }

        [ForeignKey("IdDoDepartamento")]
        public virtual Departamento Departamento { get; set; }

        public bool MalaDireta { get; set; }

        [NotMapped]
        public Telefone? Telefone { get; set; }

        public DateTime? DataDeCadastro { get; set; }

        public Contato()
        {
            this.Telefone = new Telefone();
            this.Telefones = new List<Telefone>();
            this.Nome = " ";
        }

        public string ResumirTelefones()
        {
            var telefones = "-";

            if (Telefones.Count > 0)
                telefones = string.Join(" / ", Telefones.Select(tel => string.Format("{0}{1}", string.IsNullOrEmpty(tel.DDD) ? "" : string.Format("({0}) ", tel.DDD), tel.Numero)).ToList());

            return telefones;
        }

        public dynamic ConvertToJson()
        {
            dynamic json = new ExpandoObject();

            json.Id = this.Id;
            json.Nome = this.Nome;
            json.Email = this.Email ?? "";
            json.MalaDireta = this.MalaDireta;
            json.Funcao = this.Funcao ?? "";
            json.Departamento = this.Departamento;
            json.IdDoDepartamento = this.IdDoDepartamento;
            json.ResumoTelefones = this.ResumirTelefones();
            json.Telefones = this.Telefones.Select(t => t.ConvertToJson()).ToArray();

            return json;
        }
    }
}