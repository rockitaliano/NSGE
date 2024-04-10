using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Models
{
    public class VeiculoPesquisaViewModel
    {
        [Display(Name = "Marca / Modelo / Placa")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public string? Pesquisa { get; set; }

        public string Target { get; set; }

        public VeiculoPesquisaViewModel()
        {

        }

        public VeiculoPesquisaViewModel(string pesquisa, string target)
        {
            this.Pesquisa = pesquisa;
            this.Target = target;
        }
    }
}