using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Propostas;
using NSGE.Domain.Entity.Propostas.Dtos;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces.Propostas
{
    public interface IPropostaService
    {
        public IList<Status> ListarPorTipo(TipoStatusEnum tipo);
        public Task<IList<StatusPropostaDTO>> ListarPorStatus(TipoStatusEnum tipo);
        public Task<IEnumerable<PropostaDTO>> GetPropostasAsync(PropostaFiltro filtro);
        public Task<IEnumerable<PropostaDTO>> GetPropostasByFilterAsync(PropostaFiltro filtro);
        public IList<Pessoa> ListarVendedor(TipoFuncaoPessoaEnum tipoFuncao, string nome = null);
        public Task<int> Add(PropostaDTO proposta);
        public int AlterarStatus(Proposta model);
        public Proposta Edit(Proposta model);
        public Proposta RecuperarPorId(string id);
        public int Delete(string id);

    }
}