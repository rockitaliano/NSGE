using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Agenda;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IDiariaService
    {
        public Task<IList<DiariaTecnicaGrid>> GetDiariaTecnicaGrid();

        public Task<IList<DiariaTecnicaGrid>> GetDiariaFilter(DiariaTecnicaFiltro filtro);

        public IList<DiariaTecnica> ListarPorTecnico(string tecnicoId);

        public DiariaTecnica Pesquisar(string tecnico, DateTime? dataInicial, DateTime? dataFinal, TipoFuncaoPessoaEnum tipo);
        public void AtualizarValores(IList<TecnicoDia> list);

    }
}