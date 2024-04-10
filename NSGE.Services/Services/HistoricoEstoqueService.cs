using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class HistoricoEstoqueService : IHistoricoEstoqueService
    {
        private readonly IHistoricoEstoqueRepository _repository;

        public HistoricoEstoqueService(IHistoricoEstoqueRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<HistoricoEstoque>> GetHistoricoEstoque()
        {
            return await _repository.GetAllOnlyThisYear();
        }

        public IEnumerable<Status> ListarPorTipo(TipoStatusEnum tipo)
        {            
            var enumValue = tipo.GetEnumValue();

            var lista = _repository.ListarPorTipo(enumValue);

            return lista.Where(x => x.TipoDoCadastro == enumValue).OrderBy(x => x.Descricao).ToList();

        }
    }
}