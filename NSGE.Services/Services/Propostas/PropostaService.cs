using AutoMapper;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Propostas;
using NSGE.Domain.Entity.Propostas.Dtos;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces.Propostas;

namespace NSGE.Services.Services.Propostas
{
    public class PropostaService : IPropostaService
    {
        public readonly IMapper _mapper;
        public readonly IPropostaRepository _repository;

        public PropostaService(IPropostaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Add(PropostaDTO proposta)
        {
            var propDto = _mapper.Map<Proposta>(proposta);
            return await _repository.Add(propDto);
        }

        public int AlterarStatus(Proposta model)
        {            
            return _repository.Update(model);
        }

        public int Delete(string id)
        {
            return _repository.Delete(id);
        }

        public Proposta Edit(Proposta model)
        {           
            return _repository.Edit(model);
        }

        public async Task<IEnumerable<PropostaDTO>> GetPropostasAsync(PropostaFiltro filtro)
        {
            var propFiltro = await _repository.GetPropostasAsync(filtro);
            var prop = _mapper.Map<IEnumerable<PropostaDTO>>(propFiltro);
            return prop;
        }

        public async Task<IEnumerable<PropostaDTO>> GetPropostasByFilterAsync(PropostaFiltro filtro)
        {
            var propFiltro = await _repository.GetPropostasByFilterAsync(filtro);
            var prop = _mapper.Map<IEnumerable<PropostaDTO>>(propFiltro);
            return prop;
        }

        public async Task<IList<StatusPropostaDTO>> ListarPorStatus(TipoStatusEnum tipo)
        {
            var enumTipo = tipo.GetEnumValue();
            var status = await _repository.ListarPorStatus(enumTipo);
            return status;
        }

        public IList<Status> ListarPorTipo(TipoStatusEnum tipo)
        {
            var enumValue = tipo.GetEnumValue();
            var propostas = _repository.ListarPorTipo(enumValue);

            var propostaDTO = _mapper.Map<List<Status>>(propostas);

            return propostaDTO;
        }

        public IList<Pessoa> ListarVendedor(TipoFuncaoPessoaEnum tipoFuncao, string nome = null)
        {
            var list = _repository.ListarVendedor(TipoFuncaoPessoaEnum.RepresentanteComercial);
            return list;
        }

        public Proposta RecuperarPorId(string id)
        {
            return _repository.RecuperarPorId(id);
        }
    }
}