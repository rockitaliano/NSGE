using AutoMapper;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Entity;
using NSGE.Domain.Entity.Agenda;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class DiariaService : IDiariaService
    {
        private readonly IDiariaRepository _repository;
        private readonly IMapper _mapper;

        public DiariaService(IDiariaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AtualizarValores(IList<TecnicoDia> list)
        {
            foreach (var dia in list)
            {
                _repository.AtualizarValores(list);
            }
        }

        public async Task<IList<DiariaTecnicaGrid>> GetDiariaFilter(DiariaTecnicaFiltro filtro)
        {
            var result = await _repository.GetDiariaFiltro(filtro);
            var diaria = _mapper.Map<IList<DiariaTecnicaGrid>>(result);
            return diaria;
        }

        public async Task<IList<DiariaTecnicaGrid>> GetDiariaTecnicaGrid()
        {
            return await _repository.GetDiarias();
        }

        public IList<DiariaTecnica> ListarPorTecnico(string tecnicoId)
        {
            return _repository.ListarPorTecnico(tecnicoId);
        }

        public DiariaTecnica Pesquisar(string tecnico, DateTime? dataInicial, DateTime? dataFinal, TipoFuncaoPessoaEnum tipo)
        {
            return _repository.Pesquisar(tecnico, dataInicial, dataFinal, tipo);
        }
    }
}