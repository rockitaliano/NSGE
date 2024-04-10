using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Operacional;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;
using NSGE.Services.Interfaces.OrdemServico;
using NSGE.Services.Services;
using NSGE.Services.Services.OrdemServico;
using NSGE.Services.Services.Session;

namespace NSGE.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository _repository;
        private readonly IEventoService _eventoService;
        private readonly ICheckListService _checkListService;
        private readonly IItemSublocacaoOrdemServicoVersaoService _itemSublocacaoOSVersaoService;
        private readonly IItemOrdemServicoVersaoService _itemOrdemServicoVersaoService;
        private readonly IObservacaoOrdemServicoVersaoService _observacaoOrdemServicoVersaoService;

        public OrdemServicoService(IOrdemServicoRepository repository, 
                                   IEventoService eventoService,
                                   ICheckListService checkListService,
                                   IItemSublocacaoOrdemServicoVersaoService itemSublocacaoOSVersaoService,
                                   IItemOrdemServicoVersaoService itemOrdemServicoVersaoService,
                                   IObservacaoOrdemServicoVersaoService observacaoOrdemServicoVersaoService)
        {
            _repository = repository;
            _eventoService = eventoService;
            _checkListService = checkListService;
            _itemSublocacaoOSVersaoService = itemSublocacaoOSVersaoService;
            _itemOrdemServicoVersaoService = itemOrdemServicoVersaoService;
            _observacaoOrdemServicoVersaoService = observacaoOrdemServicoVersaoService;
        }

        public OrdemServicoDadosEvento CarregarDadosEvento(string idDoEvento)
        {
            var eventoService = _eventoService.QueryEventos();

            var proposta = ArquivoAreaEnum.Proposta.EnumValue();

            var model = eventoService.Where(x => x.Id == idDoEvento)
                .Select(x => new OrdemServicoDadosEvento()
                {
                    IdEvento = idDoEvento,
                    EventoDescricao = x.Nome,
                    NumeroDaOS = x.NumeroDaOS,
                    CoordenadorTecnico = x.CoordenadorTecnico,
                    ArquivosProposta = x.Arquivos.Where(a => a.Area == proposta).ToList(),
                    IdEndereco = x.EnderecoId,
                    IdLocal = x.LocalId,
                    Local = x.LocalDoEvento,
                }).FirstOrDefault();

            var checklistService = _checkListService.Existe(model.NumeroDaOS);

            return model;
        }

        public int GetVersao(string idOrdemServico)
        {
            //var sublocacao = new ItemSublocacaoOrdemServicoVersaoService();
            //var item = ; //new ItemOrdemServicoVersaoService();
            //var observacao = ;//new ObservacaoOrdemServicoVersaoService();

            int vSub = _itemSublocacaoOSVersaoService.GetVersao(idOrdemServico);
            int vItem = _itemOrdemServicoVersaoService.GetVersao(idOrdemServico);
            int vObservacao = _observacaoOrdemServicoVersaoService.GetVersao(idOrdemServico);

            var versao = vSub > vItem ? vSub : vItem;
            return versao > vObservacao ? versao : vObservacao;
        }

        public IList<ItemSublocacaoOrdemServicoVersao> ListItemSubLocacaoServicoVersao()
        {            
            throw new NotImplementedException();
        }

        public IList<ItemOrdemServicoVersao> ListOSServicoVersao()
        {
            throw new NotImplementedException();
        }

        public OrdemServico Load(string id)
        {
            return _repository.Load(id);
        }

        public void SalvarVersaoOSServicoVersoes()
        {
            var list = SessionService.OrdemServicoVersoes;
            //list.ForEach(x => Insert(x));
            SessionService.OrdemServicoVersoes = null;
        }
    }
}