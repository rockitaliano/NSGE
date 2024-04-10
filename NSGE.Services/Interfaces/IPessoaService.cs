using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Clientes;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IPessoaService
    {
        public Task<IEnumerable<Pessoa>> GetAll();

        public Task<Pessoa> GetById(string id);

        public Task<RamoAtuacao> GetAtuacao(string id);
        public IList<Pessoa> ListByType(Pessoa tipo);
        public IEnumerable<Qualificacao> GetQualificacao();
        public IEnumerable<RamoAtuacao> GetRamoAtuacao();

        public Task<IEnumerable<PessoaFiltro>> Pesquisar(PessoaFiltro model);
        public IList<Pessoa> Listar();
        public Pessoa RetornarPessoa(string idPessoa);
        public Pessoa Load(string id);
        public IQueryable<Pessoa> Dropdown(params TipoFuncaoPessoaEnum[] funcoes);
        public IList<TecnicoDia> RetornarTecnicoDia(string AgendaId);
    }
}