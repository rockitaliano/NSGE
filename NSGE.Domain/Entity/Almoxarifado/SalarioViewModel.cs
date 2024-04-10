using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Entity.Almoxarifado
{
    public class SalarioViewModel
    {
        public string Id { get; set; }

        [Required]
        public string FuncionarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string FuncionarioNome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Salario { get; set; }

        public FuncionarioSalario ToEntity()
        {
            var entity = new FuncionarioSalario();
            entity.Id = Id ?? entity.Id;
            entity.FuncionarioId = FuncionarioId;
            entity.Salario = double.Parse(Salario ?? "0");

            return entity;
        }

        public SalarioViewModel FromEntity(FuncionarioSalario entity)
        {
            return new SalarioViewModel()
            {
                Id = entity.Id,
                FuncionarioId = entity.FuncionarioId,
                FuncionarioNome = entity.FuncionarioNome,
                Salario = entity.Salario.ToString("N2")
            };
        }
    }
}