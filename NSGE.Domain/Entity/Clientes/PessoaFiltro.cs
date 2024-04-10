using NSGE.CrosCutting.Enum;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Entity.Clientes
{
    public class PessoaFiltro
    {
        public PessoaFiltro()
        {
        }

        public string Id { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? TipoPessoa { get; set; }

        public List<Funcoes>? ListaFuncoes { get; set; }

        public string? RamoAtuacaoId { get; set; }
        public string? QualificacaoId { get; set; }
        public string? IdStatus { get; set; }
        public string? Status { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string? NomeFantasia { get; set; }

        public string? Imagem { get; set; }
        public TipoStatusEnum TesteTipoStatus { get; set; }
        public string ContatosConcat { get; set; }
    }
}