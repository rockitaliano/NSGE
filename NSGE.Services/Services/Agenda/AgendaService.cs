using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces.Agenda;

namespace NSGE.Services.Services.Agenda
{
    public class AgendaService : IAgendaService
    {
        private bool eventoRJ = true;
        private TecnicoDiaService tecService = null;

        private readonly IAgendaRepository _repository;
        private readonly IEventoRepository _eventoRepository;
        private readonly ITecnicoDiaRepository _tecnicoRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public AgendaService(IAgendaRepository repository, IEventoRepository eventoRepository, ITecnicoDiaRepository tecnicoDiaRepository, IPessoaRepository pessoaRepository)
        {
            _repository = repository;
            _eventoRepository = eventoRepository;
            _tecnicoRepository = tecnicoDiaRepository;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<IList<AgendaTecnica>> CarregarAgendaDoEvento(string eventoId)
        {
            var agendaTecnica = new List<AgendaTecnica>();
            try
            {
                var tecnicos = _repository.RetornarAgenda(eventoId);
                agendaTecnica = tecnicos.ToList();

                var i = 0;
                foreach (var item in agendaTecnica)
                {
                    i++;
                    item.Evento = _eventoRepository.RetornarEvento(eventoId);
                    item.Tecnicos = _tecnicoRepository.RetornarTecnicoDia(eventoId);

                    foreach (var tecnico in item.Tecnicos)
                    {
                        var funcionario = await _pessoaRepository.GetByIdAsync(tecnico.Id);
                        tecnico.Tecnico = funcionario;
                        
                    }
                    System.Diagnostics.Trace.WriteLine("Qtd Dias => " + i);
                }
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
            return agendaTecnica;
        }

        public IList<AgendaTecnica> ListarAgenda(DateTime? inicio, DateTime? fim)
        {
            return _repository.ListarAgenda(inicio, fim);
        }

        public IList<AgendaTecnica> Load(string id)
        {
            return _repository.RetornarAgenda(id);
        }
    }
}