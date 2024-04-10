using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class TecnicoDiaService : ITecnicoDiaService
    {
        private double valorDiariaTecnica = -1;
        private double valorDiariaCoordenador = -1;
        private double valorAlimentacaoRJ = -1;
        private double valorAlimentacaoFora = -1;

        private readonly IPessoaService _pessoaService;
        private readonly ITecnicoDiaRepository _repository;
        public TecnicoDiaService(ITecnicoDiaRepository repository, IPessoaService pessoaService)
        {
            _repository = repository;
            _pessoaService = pessoaService;
        }
        public IList<TecnicoDia> RetornarTecnicoDia(string AgendaId)
        {
            throw new NotImplementedException();
        }
    }
}