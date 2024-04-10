using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Clientes;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;
using NSGE.Services.LinqExtensions;

namespace NSGE.Services.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Pessoa> Dropdown(params TipoFuncaoPessoaEnum[] funcoes)
        {
            if (funcoes.Count() == 1 && funcoes.Any(x => x.Equals("Sublocacao")))
            {
                var result = _repository.Filter();
                result.WhereTipo(funcoes)
                .OrderBy(x => x.NomeFantasia)
                .Select(x => new Dropdown { Value = x.Id, Text = !string.IsNullOrEmpty(x.NomeFantasia) ? x.NomeFantasia + " (" + x.Nome + ")" : x.Nome })
                .ToList();

                return result;
            }

            var result2 = _repository.Filter();
            result2.WhereTipo(funcoes)
            .OrderBy(x => x.Nome)
            .ThenBy(x => x.NomeFantasia)
            .Select(x => new Dropdown { Value = x.Id, Text = !string.IsNullOrEmpty(x.NomeFantasia) ? x.NomeFantasia + " (" + x.Nome + ")" : x.Nome })
            .ToList();

            return result2;
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<RamoAtuacao> GetAtuacao(string id)
        {
            return await _repository.GetRamoAtuacaoByIdAsync(id);
        }

        public async Task<Pessoa> GetById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IEnumerable<Qualificacao> GetQualificacao()
        {
            return _repository.GetQualificacao();
        }

        public IEnumerable<RamoAtuacao> GetRamoAtuacao()
        {
            return _repository.GetRamoAtuacao();
        }

        public IList<Pessoa> Listar()
        {
            return _repository.ListarRepresentanteComercial();
        }

        public IList<Pessoa> ListByType(Pessoa tipo)
        {
            return _repository.ListByType(tipo);
        }

        public Pessoa Load(string id)
        {
            return _repository.Load(id);
        }

        public Task<IEnumerable<PessoaFiltro>> Pesquisar(PessoaFiltro model)
        {
            return _repository.Pesquisar(model);
        }

        public Pessoa RetornarPessoa(string idPessoa)
        {
            return _repository.RetornarPessoa(idPessoa);
        }

        public IList<TecnicoDia> RetornarTecnicoDia(string AgendaId)
        {
            throw new NotImplementedException();
        }
    }
}