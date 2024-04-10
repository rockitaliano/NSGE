using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Propostas;
using NSGE.Domain.Entity.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace NSGE.Domain.Models
{
    public class Evento : EntityBase
    {

        public Evento()
        {
            //this.RepresentanteComercial = new PessoaJuridica();

            //this.LocalDoEvento = new Local();

            this.Funcionarios = new List<EventoPessoa>();
            this.Hospedagem = new List<LocalEvento>();
            this.Arquivos = new List<Arquivo>();
            this.Agenda = new List<AgendaTecnica>();
            this.Contatos = new List<ContatoEvento>();
            this.Faturamentos = new List<FaturamentoEvento>();
            this.Sublocacoes = new List<EventoSublocacao>();
            this.SublocacoesRemovidas = new string[] { };

            this.Propostas = new List<EventoProposta>();

            this.VincularContatosAoCliente = new Dictionary<string, bool>();
            

            //this.UsuarioCadastro = new Usuario();
        }

        #region Propriedades

        #region Dados do Evento

        [Display(Name = "Número da OS")]
        [Required(ErrorMessageResourceName = "Required")]
        [StringLength(32, ErrorMessageResourceName = "StringLength")]
        public string NumeroDaOS { get; set; } = string.Empty;

        [Display(Name = "Nome do Evento")]
        [Required(ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceName = "StringLength")]
        public string? Nome { get; set; }

        [Display(Name = "Representante Comercial")]
        public string? IdDoRepresentanteComercial { get; set; }

        [ForeignKey("IdDoRepresentanteComercial")]
        public Pessoa? RepresentanteComercial { get; set; }

        [Display(Name = "Cliente")]
        public string? IdDoCliente { get; set; }

        [ForeignKey("IdDoCliente")]
        public Pessoa? Cliente { get; set; }

        [Display(Name = "Início do Evento")]
        public DateTime? InicioDoEvento { get; set; }

        [Display(Name = "Fim do Evento")]
        public DateTime? FimDoEvento { get; set; }

        [Display(Name = "Data da Montagem")]
        public DateTime? DataDaMontagem { get; set; }

        [Display(Name = "Hora da Montagem")]
        public TimeSpan? HoraDaMontagem { get; set; }

        //[Display(Name = "Saída para o Evento")]
        //[Required(ErrorMessageResourceName = "Required")]
        public DateTime? DataDeSaida { get; set; }

        //[Display(Name = "Data de Retorno")]
        //[Required(ErrorMessageResourceName = "Required")]
        public DateTime? DataDeRetorno { get; set; }

        [MaxLength(3000)]
        public string? Feedback { get; set; }

        [Display(Name = "Aprovado")]
        public bool Aprovado { get; set; }

        [NotMapped]
        public bool? DatasValidas
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

        #endregion Dados do Evento

        #region Local do Evento

        public string? LocalId { get; set; }

        //[ForeignKey("LocalId")]
        public Local LocalDoEvento { get; set; }

        public string? EnderecoId { get; set; }

        #endregion Local do Evento

        #region Contatos

        public IList<ContatoEvento>? Contatos { get; set; }

        [NotMapped]
        public string? JsonContatoIds { get; set; }

        public void RecuperarJsonContatos()
        {
            if (!string.IsNullOrEmpty(JsonContatoIds))
            {
                var contatoPessoaIds = System.Text.Json.JsonSerializer.Deserialize<IList<string>>(JsonContatoIds);

                this.Contatos = contatoPessoaIds.Select(x => new ContatoEvento() { ContatoId = x, EventoId = this.Id }).ToList();
            }
        }

        #region Dados Sublocações
        [NotMapped]
        public string JsonSublocacoesRemovidas { get; set; }

        [NotMapped]
        public string[] SublocacoesRemovidas { get; set; }

        [NotMapped]
        public string JsonSublocacoes { get; set; }

        public virtual ICollection<EventoSublocacao> Sublocacoes { get; set; }
        #endregion

        /// <summary>
        /// Key: ContatoId
        /// </summary>
        [NotMapped]
        public Dictionary<string, bool>? VincularContatosAoCliente { get; set; }

        #endregion Contatos
               

        #region Equipe Tecnica

        public string IdDoCoordenadorTecnico { get; set; }

        [ForeignKey("IdDoCoordenadorTecnico")]
        [Display(Name = "Coordenador Técnico")]
        public Pessoa CoordenadorTecnico { get; set; }

        public virtual IList<EventoPessoa> Funcionarios { get; set; }
        public virtual IList<LocalEvento> Hospedagem { get; set; }

        #region Arquivos
        public virtual IList<Arquivo> Arquivos { get; set; }
        #endregion

        public virtual IList<AgendaTecnica> Agenda { get; set; }

        [NotMapped]
        public IList<EventoPessoa> EquipeTecnica
        {
            get
            {
                return Funcionarios.Where(x =>
                    x.TipoEnum == TipoFuncaoPessoaEnum.Tecnico ||
                    x.TipoEnum == TipoFuncaoPessoaEnum.Freelancer ||
                    x.TipoEnum == TipoFuncaoPessoaEnum.Coordenador).ToList();
            }
        }

        #region Faturamentos
        public virtual IList<FaturamentoEvento> Faturamentos { get; set; }

        [NotMapped]
        public string JsonFaturamentoIds { get; set; }

        public void RecuperarJsonFaturamentos()
        {
            if (!string.IsNullOrEmpty(JsonFaturamentoIds))
            {
                var faturamentoIds = System.Text.Json.JsonSerializer.Deserialize<IList<string>>(JsonFaturamentoIds);

                this.Faturamentos = faturamentoIds.Select(x => new FaturamentoEvento() { IdFaturamento = x, IdEvento = this.Id }).ToList();
            }
        }
        #endregion

        [NotMapped]
        public string? JsonTecnicosSelecionados { get; set; }

        [NotMapped]
        public string? JsonAgendaTecnica { get; set; }

        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        #endregion Equipe Tecnica

        #region Equipe
        public virtual IList<EventoEquipe> Equipe { get; set; } = new List<EventoEquipe>();
        #endregion

        #region Visita tecnica

        public string IdDoTecnico { get; set; }

        /// <summary>
        /// Técnico que realizou a visita técnica
        /// </summary>
        [ForeignKey("IdDoTecnico")]
        [Display(Name = "Realizado por")]
        public Pessoa Tecnico { get; set; }

        #endregion Visita tecnica

        #region Arquivos

        //public virtual IList<Arquivo> Arquivos { get; set; }

        #endregion Arquivos

        #region Dados da Viagem

        [Display(Name = "Data da Viagem")]
        public DateTime? DataDaViagem { get; set; }

        [Display(Name = "Hora da Viagem")]
        public TimeSpan? HoraDaViagem { get; set; }

        [Display(Name = "Por conta do Cliente")]
        public bool AlimentacaoCliente { get; set; }

        [Display(Name = "Por conta do Técnico")]
        public bool AlimentacaoInfoView { get; set; }

        [Display(Name = "Veículo"), NotMapped]
        public string? VeiculoId { get; set; }

        [NotMapped]
        public string? JsonVeiculos { get; set; }

        public virtual ICollection<EventoVeiculo> Veiculos { get; set; } = new List<EventoVeiculo>();

        [Display(Name = "Motorista")]
        [NotMapped]
        public string MotoristaId { get; set; }

        [NotMapped]
        public string? JsonMotoristas { get; set; }

        #endregion Dados da Viagem
      

        #region DESPESA

        public double? DespesaSublocacao { get; set; }
        public double? DespesaHospedagem { get; set; }
        public string DescricaoHospedagem { get; set; }
        public double? DespesaImpostos { get; set; }
        public double? DespesaBV { get; set; }
        public double? DespesaOperacional { get; set; }
        public double? DespesaTransporte { get; set; }
        public string DescricaoTransporte { get; set; }
        public double? DespesasLocomocaoPessoal { get; set; }
        public string DescricaoLocomocaoPessoal { get; set; }
        public double? DespesaMaterialSuprimento { get; set; }
        public string DescricaoMaterialSuprimento { get; set; }
        public double? DespesaOutras { get; set; }
        public string DescricaoOutras { get; set; }

        [NotMapped]
        public double? DespesaImpostosValorCalculado { get; set; }

        [NotMapped]
        public double? DespesaBVValorCalculado { get; set; }

        [NotMapped]
        public double? DespesaTotal { get; set; }

        [NotMapped]
        public double? ReceitaTotal { get; set; }

        [NotMapped]
        public double? ReceitaMenosDespesa { get; set; }

        #endregion DESPESA

        #region NotMapped

        [NotMapped]
        public string? CoordenadorTecnicoNome
        {
            get
            {
                return this.CoordenadorTecnico != null ? this.CoordenadorTecnico.Nome : "";
            }
        }

        [NotMapped]
        public string? RepresentanteComercialNome
        {
            get
            {
                return this.RepresentanteComercial != null ? this.RepresentanteComercial.Nome : "";
            }
        }

        [NotMapped]
        [Display(Name = "ClienteNome")]
        public string ClienteNome
        {
            get
            {
                return Cliente != null ? Cliente.Nome : "";
            }
        }

        [NotMapped]
        [Display(Name = "Aprovado")]
        public string ApovadoTratuzido
        {
            get
            {
                return Aprovado ? "Aprovado" : "Não Aprovado";
            }
        }

        [Display(Name = "Contato(s)")]
        public string? ContatosFormatados
        {
            get
            {
                var contatos = string.Empty;

                if (Contatos != null && Contatos.Count > 0)
                {
                    var resumo = Contatos.OrderBy(x => x.Contato.Nome)
                                        .Select(x => new { Nome = x.Contato.Nome, Telefones = x.Contato.ResumirTelefones(), Email = x.Contato.Email })
                                        .Where(x => (!string.IsNullOrEmpty(x.Telefones) && !x.Telefones.Equals("-") || !string.IsNullOrEmpty(x.Email)))
                                        .ToList();

                    foreach (var item in resumo)
                    {
                        var row = "";

                        row += string.Format("{0} :", item.Nome);

                        bool temTelefones = !string.IsNullOrEmpty(item.Telefones) && !item.Telefones.Equals("-");

                        if (temTelefones)
                            row += string.Format(" {0}", item.Telefones);
                        if (!string.IsNullOrEmpty(item.Email))
                            row += string.Format(" {0}{1}", temTelefones ? "/ " : "", item.Email);

                        contatos += string.Format("{0}<br/>", row);
                    }
                }

                return contatos;
            }
        }

        [NotMapped]
        [Display(Name = "Data da montagem")]
        public string DataMontagemFormatada
        {
            get
            {
                var data = this.DataDaMontagem.HasValue ? this.DataDaMontagem.Value.ToString("dd/MM/yyyy") : "";
                //var hora = this.HoraDaMontagem.HasValue ? this.HoraDaMontagem.Value.ToString("hh\\:mm") : "";

                return string.Format("{0}", data);
            }
        }

        [NotMapped]
        [Display(Name = "Data do Evento")]
        public string DataEventoFormatada
        {
            get
            {
                return this.InicioDoEvento.HasValue ? this.InicioDoEvento.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }

        [NotMapped]
        [Display(Name = "Data Fim")]
        public string DataFimFormatada
        {
            get
            {
                return this.FimDoEvento.HasValue ? this.FimDoEvento.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }

        [NotMapped]
        [Display(Name = "Data de Retorno")]
        public string DataRetornoFormatada
        {
            get
            {
                return this.DataDeRetorno.HasValue ? this.DataDeRetorno.Value.ToString("dd/MM/yyyy") : "N/A";
            }
        }

        [NotMapped]
        [Display(Name = "Data da Saida")]
        public string DataSaidaFormatada
        {
            get
            {
                var data = this.DataDeSaida.HasValue ? this.DataDeSaida.Value.ToString("dd/MM/yyyy") : "";                

                return string.Format("{0}", data);
            }
        }

        [NotMapped]
        public string? EmpresaEndereco { get; set; }
        
        /// <summary>
        /// Hash com LocalId e EnderecoId
        /// LOCALID#ENDERECOID|LOCALID#ENDERECOID|LOCALID#ENDERECOID|LOCALID#ENDERECOID
        /// </summary>
        [NotMapped]
        public string HospedagensSelecionadas { get; set; }

        #endregion NotMapped

        #region IAuditoria

        public string UsuarioCadastroId { get; set; }

        [ForeignKey("UsuarioCadastroId")]
        public Usuario? UsuarioCadastro { get; set; }

        public string? UsuarioAlteracaoId { get; set; }

        [ForeignKey("UsuarioAlteracaoId")]
        public Usuario? UsuarioAlteracao { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public DateTime? DataDeAlteracao { get; set; }

        #endregion IAuditoria

        public IList<EventoProposta> Propostas { get; set; }

        [NotMapped]
        public IList<EventoPessoa> Motoristas
        {
            get
            {
                return Funcionarios.Where(x => x.TipoEnum == TipoFuncaoPessoaEnum.Motorista).ToList();
            }
        }

        [NotMapped]
        public Proposta? Proposta { get; set; }

        [NotMapped]
        public string? JsonPropostaIds { get; set; }

        public void RecuperarJsonPropostas()
        {
            if (!string.IsNullOrEmpty(JsonPropostaIds))
            {
                var propostasIds = System.Text.Json.JsonSerializer.Deserialize<IList<string>>(JsonPropostaIds);

                this.Propostas = propostasIds.Select(x => new EventoProposta() { PropostaId = x, EventoId = this.Id }).ToList();
            }
        }
        public dynamic ConvertToJson()
        {
            dynamic json = new ExpandoObject();

            json.Id = this.Id;
            json.Nome = this.Nome;
            json.NumeroDaOS = this.NumeroDaOS;

            return json;
        }

        #endregion Propriedades
    }
}