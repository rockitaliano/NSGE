using AutoMapper;
using NSGE.Domain.Dtos.CheckList;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity.CheckList;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class CheckListService : ICheckListService
    {
        private readonly ICheckListRepository _repository;
        private readonly IMapper _mapper;
        public CheckListService(ICheckListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int BuscarQuantidadeItem(string os, string itemId)
        {
            return _repository.BuscarQuantidadeItem(os, itemId);
        }

        public EventoDto CarregarOS(string numeroDaOS)
        {
            
            return _repository.CarregarOS(numeroDaOS);
        }

        public string CarregarResponsavel(string numeroDaOS)
        {
            throw new NotImplementedException();
        }

        public IList<string> ContatosDoEvento(string numeroDaOS)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id, int result)
        {
            return _repository.Delete(id, result);
        }

        public bool Existe(string numeroDaOS)
        {
            return _repository.Existe(numeroDaOS);
        }

        public async Task<IList<CheckListGrid>> GetByOs(CheckListFiltro numeroOs)
        {
            var map = _mapper.Map<CheckListGrid>(numeroOs);
            return await _repository.GetByOs(map);
        }

        public async Task<IList<CheckListGrid>> GetCheckList()
        {
            return await _repository.GetAllOs();
        }

        public IList<ItemChecklist> ListarFilhos(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
                return new List<ItemChecklist>();

            return _repository.ListarFilhos(parentId);
        }

        public IList<ItemChecklist> ListarPais()
        {
            return _repository.ListarPais();
        }

        public ChecklistExtra LoadPorOS(string numeroDaOS)
        {
            return _repository.LoadPorOS(numeroDaOS);
        }

        public IList<string> OperadoresPorOS(string numeroDaOS)
        {
            return _repository.OperadoresPorOS(numeroDaOS);
        }

        public int RecuperarVersao(string numeroDaOS)
        {
            throw new NotImplementedException();
        }

        public bool TemFilhos(string parentId)
        {
            return _repository.TemFilhos(parentId);
        }
    }
}