using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Almoxarifado;
using NSGE.Domain.Entity.Clientes;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces.Almoxarifado;
using NSGE.Services.Interfaces.Almoxarifado;
using NSGE.Services.LinqExtensions;

namespace NSGE.Services.Services.Almoxarifado
{
    public class AlmoxarifadoService : IAlmoxarifadoService
    {
        private readonly IAlmoxarifadoRepository _repository;

        public AlmoxarifadoService(IAlmoxarifadoRepository repository)
        {
            _repository = repository;
        }

        public Task Delete(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public IList<TipoServico> DropDown()
        {
            var dropdownList = (from x in _repository.Dropdown()
                                        orderby x.Descricao
                                        select new Dropdown() { Value = x.Id, Text = x.Descricao })
                                .ToList();

            var tipoServicoList = dropdownList.Select(x => new TipoServico()
            {
                Id = x.Value,
                Descricao = x.Text
            }).ToList();

            return tipoServicoList;
        }

        public IList<Pessoa> DropDownPessoa(params TipoFuncaoPessoaEnum[] funcoes)
        {
            var dropdown = _repository.DropDownPessoa()
                        .WhereTipo(funcoes)
                        .OrderBy(x => x.Name)
                        .ThenBy(x => x.NomeFantasia)
                        .Select(x => new Dropdown { Value = x.Id, Text = !string.IsNullOrEmpty(x.Name) ? x.Name + " (" + x.Nome + ")" : x.Nome })
                        .ToList();
            //var dropdownList = (from x in _repository.DropDownPessoa()
            //                    orderby x.Nome
            //                    select new Dropdown() { Value = x.Id, Text = x.Name })
            //                    .ToList();

            var pessoa = dropdown.Select(x => new Pessoa()
            {
                Id = x.Value,
                Nome = x.Text
            }).ToList();

            return pessoa;
               
        }

        public async Task<IList<RegistroViewModel>> FindBy(string? pessoaId, string? eventoId, DateTime? dataInicio, DateTime? dataFim)
        {
            var registros = _repository.GetAlmoxarifadoAsync();
            var servicos = await _repository.ServicoAlmoxarife();
            var tipos = await _repository.GetTipoServico();
            var eventos = await _repository.GetEventos();
            try
            {
                var query = from r in registros
                            join s in servicos on r.ServicoAlmoxarifeId equals s.Id
                            join t in tipos on r.TipoServicoId equals t.Id
                            join e in eventos on s.EventoId equals e.Id into es
                            from e in es.DefaultIfEmpty() //left outer join
                            where (s.PessoaId == pessoaId) &&
                                   (string.IsNullOrEmpty(eventoId) || s.EventoId == eventoId) &&
                                   (!dataInicio.HasValue || r.Data >= dataInicio) &&
                                   (!dataFim.HasValue || r.Data <= dataFim)
                            orderby r.Data
                            select new RegistroViewModel()
                            {
                                Id = r.Id,
                                AlmoxarifeId = r.ServicoAlmoxarifeId,
                                NumeroOS = e != null ? e.NumeroDaOS : null,
                                Evento = e != null ? e.Nome : null,
                                TipoServicoDescricao = t.Descricao,
                                TipoServicoId = t.Id,
                                ValorServicoPago = r.ServicoPago,
                                ValorAlimentacaoPago = r.AlimentacaoPago,
                                Total = r.ValorServico + r.ValorAlimentacao,
                                // db fields
                                DbData = r.Data,
                                DbDataFim = r.DataFim,
                                DbHoraInicio = r.HoraInicio,
                                DbHoraFim = r.HoraFim,
                                DbValorServico = r.ValorServico,
                                DbValorAlimentacao = r.ValorAlimentacao,
                            };

                return query.ToList().Select(x => x.ConvertDbFields()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<ServicoAlmoxarifeRegistro>> GetAlmoxarifadoAsync()
        {
            var retorno = _repository.GetAlmoxarifadoAsync();
            return await Task.FromResult(retorno);
        }

        //public async Task<IList<Evento>> GetEventos()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<PessoaFiltro> GetNome(string pessoaId)
        {
            return await _repository.GetNome(pessoaId);
        }

        //public Task<IList<TipoServico>> GetTipoServico()
        //{
        //    throw new NotImplementedException();
        //}

        public IList<AlmoxarifadoIndexViewModel> Grid(string? eventoId, string? pessoaId, DateTime? dataInicio, DateTime? dataFim)
        {
            var registros = _repository.GetRegistros().Result;
            var servicos = _repository.ServicoAlmoxarife().Result;
            var pessoas = _repository.GetPessoas().Result;

            var query =

            (from registro in registros
             join servico in servicos on registro.ServicoAlmoxarifeId equals servico.Id
             join pessoa in pessoas on servico.PessoaId equals pessoa.Id
             where
                 (string.IsNullOrEmpty(eventoId) || servico.EventoId == eventoId) &&
                 (string.IsNullOrEmpty(pessoaId) || servico.PessoaId == pessoaId) &&
                 (!dataInicio.HasValue || registro.Data >= dataInicio) &&
                 (!dataFim.HasValue || registro.Data <= dataFim)
             group registro by new
             {
                 /*id*/
                 pessoa.Id,
                 /*nome*/
                 pessoa.Nome,
                 /*funcao*/
                 pessoa.Cliente,
                 pessoa.Fornecedor,
                 pessoa.Freelancer,
                 pessoa.Funcionario,
                 pessoa.Motorista,
                 pessoa.Almoxarife,
                 pessoa.Produtor,
                 pessoa.RepresentanteComercial,
                 pessoa.Tecnico,
                 pessoa.Transportadora
             } into grouped
             select new AlmoxarifadoIndexViewModel
             {
                 PessoaId = grouped.Key.Id,
                 PessoaNome = grouped.Key.Nome,
                 Total = grouped.Sum(x => x.ValorAlimentacao + x.ValorServico),
                 DataInicial = dataInicio,
                 DataFinal = dataFim,
                 Funcao =
                     grouped.Key.Motorista ? "Motorista" :
                     grouped.Key.Almoxarife ? "Almoxarife" :
                     grouped.Key.Tecnico ? "Tecnico" :
                     grouped.Key.Freelancer ? "Freelancer" :
                     grouped.Key.Funcionario ? "Funcionario" :
                     grouped.Key.Cliente ? "Cliente" :
                     grouped.Key.Fornecedor ? "Fornecedor" :
                     grouped.Key.Produtor ? "Produtor" :
                     grouped.Key.RepresentanteComercial ? "Representante Comercial" :
                     grouped.Key.Transportadora ? "Transportadora" : ""
             }).OrderBy(x => x.PessoaNome);

            return new List<AlmoxarifadoIndexViewModel>(query);
        }

        public async Task<ServicoAlmoxarifeRegistro> Load(string id)
        {
            return await _repository.Load(id);
        }

        //public Task<IList<ServicoAlmoxarife>> ServicoAlmoxarife()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task Update(IEnumerable<ServicoAlmoxarifeRegistro> list)
        {
            //await list.ToList().ForEach(x => _repository.Update(x));
        }
    }
}