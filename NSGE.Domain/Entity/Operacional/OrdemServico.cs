using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NSGE.Domain.Entity.Associative;
using NSGE.CrosCutting.Messages;
using System.Text.Json;

namespace NSGE.Domain.Entity.Operacional
{
    public class OrdemServico : EntityBase
    {
        public OrdemServico()
        {
            Contatos = new List<ContatoOrdemServico>();
            Itens = new List<ItemOrdemServico>();
            ItensSublocacao = new List<ItemSublocacaoOrdemServico>();
            Motoristas = new List<MotoristaOrdemServico>();
        }

        #region Dados da OS
        [Display(Name = "Número")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        //[StringLength(32, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string NumeroDaOS { get; set; }

        [Display(Name = "Descrição")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        //[StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MessageValidate))]
        public string Nome { get; set; }

        [Display(Name = "Representante Comercial")]
        public string IdDoRepresentanteComercial { get; set; }

        [ForeignKey("IdDoRepresentanteComercial")]
        public virtual Pessoa RepresentanteComercial { get; set; }

        [Display(Name = "Cliente")]
        public string IdDoCliente { get; set; }

        [ForeignKey("IdDoCliente")]
        public Pessoa Cliente { get; set; }

        [Display(Name = "Almoxarife Responsável")]
        public string IdDoAlmoxarife { get; set; }

        [ForeignKey("IdDoAlmoxarife")]
        public virtual Pessoa Almoxarife { get; set; }

        public bool Cliente1 { get; set; }
        public bool Fornecedor1 { get; set; }
        public bool Funcionario1 { get; set; }
        public bool Sublocacao1 { get; set; }
        public bool Freelancer1 { get; set; }
        public bool Transportadora1 { get; set; }
        public bool Motorista1 { get; set; }
        public bool Tecnico1 { get; set; }
        public bool RepresentanteComercial1 { get; set; }
        public bool Produtor1 { get; set; }
        public bool Almoxarife1 { get; set; }

        [NotMapped]
        public string AlmoxarifeNome
        {
            get
            {
                return Almoxarife != null ? Almoxarife.Nome : "";
            }
        }

        [Display(Name = "Início do Evento")]
        public DateTime? InicioDoEvento { get; set; }

        [Display(Name = "Fim do Evento")]
        public DateTime? FimDoEvento { get; set; }

        [Display(Name = "Data da Montagem")]
        public DateTime? DataDaMontagem { get; set; }

        [Display(Name = "Hora da Montagem")]
        public TimeSpan? HoraDaMontagem { get; set; }

        [Display(Name = "Saída para o Evento")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public DateTime? DataDeSaida { get; set; }

        [Display(Name = "Data de Retorno")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MessageValidate))]
        public DateTime? DataDeRetorno { get; set; }

        [NotMapped]
        public bool DatasValidas
        {
            get
            {
                var valido = true;

                if (InicioDoEvento.HasValue && FimDoEvento.HasValue)
                    valido = InicioDoEvento <= FimDoEvento;

                if (valido)
                {
                    if (DataDeSaida.HasValue && DataDeRetorno.HasValue)
                        valido = DataDeSaida <= DataDeRetorno;
                    else
                        valido = false;
                }

                return valido;
            }
        }
        #endregion

        #region Local da OS
        public string LocalId { get; set; }

        [ForeignKey("LocalId")]
        public virtual Local Local { get; set; }
        //Endereco principal
        public string EnderecoId { get; set; }
        #endregion

        #region Contatos
        public virtual IList<ContatoOrdemServico> Contatos { get; set; }

        [NotMapped]
        public string JsonContatoIds { get; set; }
        #endregion

        #region Itens
        public virtual IList<ItemOrdemServico> Itens { get; set; }

        public virtual IList<ItemSublocacaoOrdemServico> ItensSublocacao { get; set; }
        #endregion

        #region Motoristas
        public virtual IList<MotoristaOrdemServico> Motoristas { get; set; }

        [NotMapped]
        public string JsonMotoristas { get; set; }

        public IList<MotoristaOrdemServico> RecuperarMotoristasDaTela()
        {
            this.Motoristas = new List<MotoristaOrdemServico>();

            if (!string.IsNullOrEmpty(JsonMotoristas))
                this.Motoristas = JsonMotoristas.Split(',').Select(x => new MotoristaOrdemServico() { IdOrdemServico = this.Id, IdPessoa = x.Trim() }).ToList();

            return this.Motoristas;
        }

        public void PreencherJsonMotoristas()
        {
            if (this.Motoristas.Count > 0)
                this.JsonMotoristas = this.Motoristas.Select(x => x.IdPessoa).Aggregate((x, y) => string.Format("{0},{1}", x, y));
        }

        #endregion

        #region Evento
        public string IdDoEvento { get; set; }


        [ForeignKey("IdDoEvento")]
        public virtual Evento Evento { get; set; }
        #endregion

        #region IAuditoria
        public DateTime DataDeCadastro { get; set; }

        public DateTime? DataDeAlteracao { get; set; }

        public string UsuarioCadastroId { get; set; }

        public string UsuarioAlteracaoId { get; set; }
        #endregion

        #region CUSTOMGRID
        [NotMapped]
        public string EmpresaEndereco { get; set; }

        [Display(Name = "Cliente")]
        public string ClienteNome
        {
            get
            {
                var nome = string.Empty;

                if (Cliente != null)
                    nome = Cliente.Nome;

                return nome;
            }
        }

        [Display(Name = "Evento")]
        public string EventoNome
        {
            get
            {
                var nome = string.Empty;

                if (Evento != null)
                    nome = Evento.Nome;

                return nome;
            }
        }

        [Display(Name = "Data Evento")]
        public string DataFormatada
        {
            get
            {
                var data = string.Empty;

                if (InicioDoEvento.HasValue)
                    data = InicioDoEvento.Value.ToString("dd/MM/yyyy");

                return data;
            }
        }
        #endregion

        #region RELACIONAMENTO
        public virtual ICollection<EntradaEstoque> EntradasNoEstoque { get; set; }
        #endregion

        public void RecuperarJsonContatos()
        {
            if (!string.IsNullOrEmpty(JsonContatoIds))
            {
                var contatoPessoaIds = JsonSerializer.Deserialize<IList<string>>(JsonContatoIds);

                this.Contatos = contatoPessoaIds.Select(x => new ContatoOrdemServico() { ContatoId = x, OrdemServicoId = this.Id }).ToList();
            }
        }
    }
}