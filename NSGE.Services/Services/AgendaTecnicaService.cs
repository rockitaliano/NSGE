using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class AgendaTecnicaService : IAgendaTecnicaService
    {
        private readonly IAgendaTecnicaRepository _repository;
        private readonly IEventoService _eventoService;
        private readonly ITecnicoDiaService _tecnicoDiaService;
        private readonly IPessoaService _pessoaService;
        public AgendaTecnicaService(IAgendaTecnicaRepository repository, IEventoService eventoService, ITecnicoDiaService tecnicoDiaService, IPessoaService pessoaService)
        {
            _repository = repository;
            _eventoService = eventoService;
            _tecnicoDiaService = tecnicoDiaService;
            _pessoaService = pessoaService;

        }

        public IList<AgendaTecnica> CarregarAgendaDoEvento(string eventoId)
        {
            var tipoEnum = new TipoFuncaoPessoaEnum();
            var agendaTecnica = new List<AgendaTecnica>();

            var tecnicos =  _repository.CarregarAgendaDoEvento(eventoId);
            agendaTecnica = tecnicos.ToList();

            var i = 0;
            foreach (var item in agendaTecnica)
            {
                i++;
                item.Evento = _eventoService.RetornarEvento(eventoId).Result;
                item.Tecnicos = _tecnicoDiaService.RetornarTecnicoDia(eventoId);

                foreach (var tecnico in item.Tecnicos)
                {
                    tipoEnum.Equals(tecnico.Tipo);
                    var funcionario = _pessoaService.RetornarPessoa(tecnico.TecnicoId);
                    tecnico.Tecnico = (Pessoa)funcionario;
                }

                System.Diagnostics.Trace.WriteLine("Qtde Dias => " + i);
            }

            return agendaTecnica;

        }
    }
}