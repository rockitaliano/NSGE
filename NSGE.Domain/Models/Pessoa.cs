using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Associative;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace NSGE.Domain.Models
{
    public class Pessoa : EntityBase
    {
        
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? TipoPessoa { get; set; }
        public bool Cliente { get; set; }
        public bool Produtor { get; set; }
        public bool Fornecedor { get; set; }
        public bool Funcionario { get; set; }
        public bool Freelancer { get; set; }
        public bool Transportadora { get; set; }
        public bool Motorista { get; set; }

        [Display(Name = "Técnico")]
        public bool Tecnico { get; set; }
        public bool RepresentanteComercial { get; set; }
        public bool Almoxarife { get; set; }
        public bool Sublocacao { get; set; }
        public string? ReferenciaBancaria { get; set; }
        public string? Email { get; set; }
        public string? PaginaWeb { get; set; }
        public string? Observacao { get; set; }
        public DateTime? DataDeCadastro { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
        public IList<EnderecoPessoa>? Enderecos { get; set; }
        public IList<ContatoPessoa>? Contatos { get; set; }
        public string? ContatosConcat { get; set; }
        public string? IdStatus { get; set; }
        //public List<Status>? Status { get; set; }
        public string? Status { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string? NomeFantasia { get; set; }
        public string? Name { get; set; }

        public string? Imagem { get; set; }

        [Display(Name = "Diária Alimentação RJ")]
        [RegularExpression("[0-9]+(,[0-9][0-9]?)?", ErrorMessage = "Formato de moeda inválido")]
        public double? AlimentacaoRJ { get; set; }

        [Display(Name = "Diária Alimentação Fora")]
        [RegularExpression("[0-9]+(,[0-9][0-9]?)?", ErrorMessage = "Formato de moeda inválido")]
        public double? AlimentacaoForaRJ { get; set; }


        [Display(Name = "Diária Técnica")]
        [RegularExpression("[0-9]+(,[0-9][0-9]?)?", ErrorMessage = "Formato de moeda inválido")]
        public double? DiariaTecnica { get; set; }

        [Display(Name = "Diária Coordenador")]
        [RegularExpression("[0-9]+(,[0-9][0-9]?)?", ErrorMessage = "Formato de moeda inválido")]
        public double? DiariaCoordenador { get; set; }

        [NotMapped]
        public string? JsonContatosPessoa { get; set; }
        public TipoStatusEnum TesteTipoStatus { get; set; }
        public string? RamoAtuacaoId { get; set; }
        public string? QualificacaoId { get; set; }


        #region Relacionamentos
        public virtual IList<EnderecoPessoa> Endereco { get; set; }
        public virtual IList<ContatoPessoa> Contato { get; set; }
        public virtual IList<PessoaRamoAtuacao> PessoaRamoAtuacaoLista { get; set; }
        public virtual IList<PessoaQualificacao> PessoaQualificacaoLista { get; set; }

        [ForeignKey("IdDoCliente")]
        public virtual ICollection<Evento> Eventos { get; set; }
        #endregion

        public ICollection<RamoAtuacao>? RamoAtuacaoLista { get; set; }

        public ICollection<Qualificacao>? QualificacaoLista { get; set; }

        [NotMapped, Display(Name = "Funções")]
        public string FuncaoDescricao
        {
            get
            {
                string funcoes = "";

                if (this.Cliente)
                    funcoes += "Cliente / ";
                if (this.Fornecedor)
                    funcoes += "Fornecedor / ";
                if (this.Funcionario)
                    funcoes += "Funcionário / ";
                if (this.Freelancer)
                    funcoes += "Freelancer / ";
                if (this.Tecnico)
                    funcoes += "Técnico / ";
                if (this.RepresentanteComercial)
                    funcoes += "Representante Comercial / ";
                if (this.Motorista)
                    funcoes += "Motorista / ";
                if (this.Transportadora)
                    funcoes += "Trasportadora / ";

                if (!string.IsNullOrEmpty(funcoes))
                    funcoes = funcoes.Remove(funcoes.LastIndexOf(" / "));

                return funcoes;
            }
        }

        public Pessoa()
        {
            this.Enderecos = new List<EnderecoPessoa>();
            this.Contatos = new List<ContatoPessoa>();
            this.PessoaRamoAtuacaoLista = new List<PessoaRamoAtuacao>();
            this.PessoaQualificacaoLista = new List<PessoaQualificacao>();
        }

        public string RecuperarFuncao(Pessoa pessoa)
        {
            var funcao = "";

            if (pessoa.Cliente) funcao = "Cliente";
            if (pessoa.Fornecedor) funcao = "Fornecedor";
            if (pessoa.Freelancer) funcao = "Freelancer";
            if (pessoa.Funcionario) funcao = "Funcionario";
            if (pessoa.Motorista) funcao = "Motorista";
            if (pessoa.Produtor) funcao = "Produtor";
            if (pessoa.RepresentanteComercial) funcao = "RepresentanteComercial";
            if (pessoa.Tecnico) funcao = "Tecnico";
            if (pessoa.Transportadora) funcao = "Transportadora";
            
            return funcao;
        }
    }

}