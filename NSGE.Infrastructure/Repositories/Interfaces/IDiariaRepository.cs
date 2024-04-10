using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Agenda;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IDiariaRepository
    {
        public Task<IList<DiariaTecnicaGrid>> GetDiarias();
        public Task<IList<DiariaTecnicaGrid>> GetDiariaFiltro(DiariaTecnicaFiltro filtro);
        public IList<DiariaTecnica> ListarPorTecnico(string tecnicoId);
        public DiariaTecnica Pesquisar(string tecnico, DateTime? dataInicial, DateTime? dataFinal, TipoFuncaoPessoaEnum tipo);
        public void AtualizarValores(IList<TecnicoDia> list);
    }
}