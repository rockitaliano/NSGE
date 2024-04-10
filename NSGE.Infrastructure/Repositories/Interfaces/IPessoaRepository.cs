using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Entity.Clientes;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetAllAsync();

        Task<Pessoa> GetByIdAsync(string id);

        Task Create(Pessoa pessoa);

        Task Update(Pessoa pessoa);

        Task Delete(string id);

        Task<RamoAtuacao> GetRamoAtuacaoByIdAsync(string id);
        public IList<Pessoa> ListByType(Pessoa tipoStatus);

        public IEnumerable<Qualificacao> GetQualificacao();
        public IEnumerable<RamoAtuacao> GetRamoAtuacao();
        public Task<IEnumerable<PessoaFiltro>> Pesquisar(PessoaFiltro model);
        public List<Pessoa> Filtro(PessoaFiltro model);
        public Pessoa RetornarPessoa(string idPessoa);
        public Pessoa Load(string id);
        public IQueryable<Pessoa> Filter();
        public IList<Pessoa> ListarRepresentanteComercial();
    }
}