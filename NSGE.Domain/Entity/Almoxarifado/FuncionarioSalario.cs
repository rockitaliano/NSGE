using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Almoxarifado
{
    public class FuncionarioSalario : EntityBase
    {
        public string FuncionarioId { get; set; }
        public double Salario { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual Pessoa? Funcionario { get; set; }
        public string FuncionarioNome { get; set; }
    }
}