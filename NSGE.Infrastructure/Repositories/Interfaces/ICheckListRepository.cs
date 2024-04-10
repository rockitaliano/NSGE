using NSGE.Domain.Dtos.CheckList;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity.CheckList;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface ICheckListRepository
    {
        public Task<IList<CheckListGrid>> GetAllOs();
        public Task<IList<CheckListGrid>> GetByOs(CheckListGrid numeroOs);
        public Task Delete(string id, int result);

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
        public EventoDto CarregarOS(string numeroDaOS);

    }
}