using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Propostas;
using NSGE.Domain.Entity.Propostas.Dtos;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IPropostaRepository
    {
        public IList<Status> ListarPorTipo(string tipo);

        public Task<IList<StatusPropostaDTO>> ListarPorStatus(string tipo);
        public Task<IList<Proposta>> GetPropostasAsync(PropostaFiltro filtro);
        public Task<IList<Proposta>> GetPropostasByFilterAsync(PropostaFiltro filtro);
        public IList<Pessoa> ListarVendedor(TipoFuncaoPessoaEnum tipoFuncao, string nome = null);
        public Task<int> Add(Proposta proposta);
        public Proposta AlterarStatus(Proposta model);

        public int Update(Proposta model);
        public Proposta Edit(Proposta model);
        public Proposta RecuperarPorId(string id);
        public int Delete(string id);
    }
}