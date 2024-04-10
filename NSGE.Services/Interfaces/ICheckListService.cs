using NSGE.Domain.Dtos.CheckList;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity.CheckList;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface ICheckListService
    {
        public Task<IList<CheckListGrid>> GetCheckList();
        public Task<IList<CheckListGrid>> GetByOs(CheckListFiltro numeroOs);
        public Task Delete(string id, int result);
        public EventoDto CarregarOS(string numeroDaOS);
        public string CarregarResponsavel(string numeroDaOS);
        public IList<string> OperadoresPorOS(string numeroDaOS);
        public IList<string> ContatosDoEvento(string numeroDaOS);
        public int RecuperarVersao(string numeroDaOS);
        public bool Existe(string numeroDaOS);
        public ChecklistExtra LoadPorOS(string numeroDaOS);
        public IList<ItemChecklist> ListarPais();
        public IList<ItemChecklist> ListarFilhos(string parentId);
        public int BuscarQuantidadeItem(string os, string itemId);
        public bool TemFilhos(string parentId);

    }
}