using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;
using NSGE.Services.Interfaces.Agenda;
using NSGE.Services.Interfaces.Financeiro;
using NSGE.Services.Services.Agenda;
using ZstdSharp.Unsafe;

namespace NSGE.Services.Services
{
    public class EventoService : IEventoService
    {
        private string[] ignoreOnUpdate = { "UsuarioCadastroId", "DataDeCadastro" };

        private readonly IEventoRepository _repository;
        private readonly IAgendaService _agendaService;
        private readonly ILocalService _localService;
        private readonly IContatoEventoService _contatoEventoService;
        private readonly IFaturamentoService _faturamentoService;
        private readonly IPessoaService _pessoaService;
        private readonly IContatoPessoaService _contatoPessoaService;
        private readonly IEventoRepository _eventoRepository;
        private readonly IArquivoService _arquivoService;       
        private readonly IEventoVeiculoService _eventoVeiculoService;
        private readonly IEventoSublocacaoService _eventoSublocacaoService;
        private readonly IEventoEquipeService _eventoEquipeService;
        private readonly IEventoPropostaService _eventoPropostaService;

        public EventoService(IEventoRepository repository, 
            IAgendaService agendaService, 
            ILocalService localService, 
            IContatoEventoService contatoEventoService,
            IFaturamentoService faturamentoService,
            IPessoaService pessoaService,
            IContatoPessoaService contatoPessoaService,
            IEventoRepository eventoRepository,
            IArquivoService arquivoService,
            IEventoVeiculoService eventoVeiculoService,
            IEventoSublocacaoService eventoSublocacaoService,
            IEventoEquipeService eventoEquipeService,
            IEventoPropostaService eventoPropostaService)
        {
            _repository = repository;
            _agendaService = agendaService;
            _localService = localService;
            _contatoEventoService = contatoEventoService;
            _faturamentoService = faturamentoService;
            _pessoaService = pessoaService;
            _contatoPessoaService = contatoPessoaService;
            _eventoRepository = eventoRepository;
            _arquivoService = arquivoService;
            _eventoVeiculoService = eventoVeiculoService;
            _eventoSublocacaoService = eventoSublocacaoService;
            _eventoEquipeService = eventoEquipeService;
            _eventoPropostaService = eventoPropostaService;
        }

        public Evento CarregarOS(string numeroDaOS)
        {
            return _repository.CarregarOS(numeroDaOS);
        }

        public async Task<IList<EventoGrid>> Filtrar(EventoGrid model)
        {
            return await _repository.Filtrar(model);
        }

        public async Task<IList<EventoGrid>> ListarEventos()
        {
            return await _repository.ListarEventos();
        }

        public async Task<Evento> Load(string id, bool carregarAgenda)
        {
            //var evento = _agendaService.Load(id);
           
            var evento = _eventoRepository.RetornarEvento(id);
            if (evento != null)
            {
                evento = RetornarEvento(id).Result;

                if (carregarAgenda)
                    evento.Agenda = await _agendaService.CarregarAgendaDoEvento(id);
            }
            return evento;
        }

        public async Task<Evento> RetornarEvento(string idEvento)
        {
            var evento = _repository.RetornarEvento(idEvento);
            if (evento != null)
            {
                var eventoEndereco = await _localService.Load(evento.LocalId);
                if(eventoEndereco != null)                
                    evento.LocalDoEvento = eventoEndereco;
               

                var contatoEvento = _contatoEventoService.RetornarContatoEvento(idEvento);                
                if(contatoEvento != null)
                    evento.Contatos = contatoEvento;

                var faturamentoEvento = _faturamentoService.RetornarFaturamentoEvento(idEvento);
                if (faturamentoEvento != null)
                {
                    foreach (var item in faturamentoEvento)
                    {
                        item.Faturamento.RecuperarJsonStatus();
                    }
                    evento.Faturamentos = faturamentoEvento;
                };

                if(evento.IdDoCliente != null)
                {
                    var cliente = new Pessoa();
                    cliente = _pessoaService.RetornarPessoa(evento.IdDoCliente);
                    var contatoPessoaService = _contatoPessoaService.RecuperarPorPessoa(evento.IdDoCliente);
                    cliente.Contatos = contatoPessoaService;

                    evento.Cliente = cliente;
                }

                var eventoPessoas = _eventoRepository.ListarPorEvento(idEvento);

                if (eventoPessoas.Count() != 0)
                    evento.Funcionarios = eventoPessoas;

                if(evento.IdDoCoordenadorTecnico != null)
                {
                    var eventoCoordenadorTecnico = _pessoaService.Load(evento.IdDoCoordenadorTecnico);
                    if (eventoCoordenadorTecnico != null)
                        evento.CoordenadorTecnico = eventoCoordenadorTecnico;
                }

                if(evento.IdDoRepresentanteComercial != null)
                {
                    var eventoRepresentanteComercial = _pessoaService.Load(evento.IdDoRepresentanteComercial);

                    if (eventoRepresentanteComercial != null)
                    {
                        evento.RepresentanteComercial = eventoRepresentanteComercial;
                    }
                }

                if(evento.IdDoTecnico != null)
                {
                    var eventoTecnico = _pessoaService.Load(evento.IdDoTecnico);
                    if (eventoTecnico != null)
                        evento.Tecnico = eventoTecnico;
                }

                var eventoArquivos = _arquivoService.ListarPorEvento(evento.Id);
                if(eventoArquivos.Count() != 0)
                    evento.Arquivos = eventoArquivos;


                var eventoHospedagem = _localService.RecuperarHospedagens(evento.Id);
                if (eventoHospedagem.Count() != 0)
                {
                    evento.Hospedagem = eventoHospedagem;
                }

                var eventoVeiculos = _eventoVeiculoService.ListBy(evento.Id);
                if(eventoVeiculos.Count() != 0)
                    evento.Veiculos = eventoVeiculos;

                var eventoSubLocacao = _eventoSublocacaoService.ListarPorEvento(evento.Id);
                if(eventoSubLocacao.Count() != 0)
                    evento.Sublocacoes = eventoSubLocacao;


                var eventoEquipeTecnica = _eventoEquipeService.ListarPorEvento(evento.Id);

                if (eventoEquipeTecnica.Count() != 0)
                {
                    evento.Equipe = eventoEquipeTecnica;
                }

                var eventoProposta = _eventoPropostaService.RetornarEventoProposta(idEvento);

                if (eventoProposta.Count != 0)
                {
                    evento.Propostas = eventoProposta;
                };
            }

            return evento;
                
        }

        public IList<Evento> QueryEventos()
        {
            return _repository.QueryEventos();
        }
    }
}