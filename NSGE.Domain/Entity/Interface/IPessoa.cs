using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Models;

namespace NSGE.Domain.Entity.Interface
{
    public interface IPessoa
    {
        string Id { get; set; }
        string Nome { get; set; }
        string Documento { get; set; }
        DateTime? DataNascimento { get; set; }
        string TipoPessoa { get; set; }
        bool Cliente { get; set; }
        bool Fornecedor { get; set; }
        bool Funcionario { get; set; }
        bool Freelancer { get; set; }
        bool Transportadora { get; set; }
        bool Motorista { get; set; }
        bool RepresentanteComercial { get; set; }
        string ReferenciaBancaria { get; set; }
        string Email { get; set; }
        string PaginaWeb { get; set; }
        string Observacao { get; set; }
        //DateTime DataDeCadastro { get; set; }
        DateTime? DataDeAlteracao { get; set; }
        IList<EnderecoPessoa> Enderecos { get; set; }
        IList<ContatoPessoa> Contatos { get; set; }
        string IdStatus { get; set; }
        //Status Status { get; set; }

        //IList<PessoaRamoAtuacao> PessoaRamoAtuacaoLista { get; set; }
        //IList<PessoaQualificacao> PessoaQualificacaoLista { get; set; }

        //ICollection<RamoAtuacao> RamoAtuacaoLista { get; set; }
        //ICollection<Qualificacao> QualificacaoLista { get; set; }
    }
}