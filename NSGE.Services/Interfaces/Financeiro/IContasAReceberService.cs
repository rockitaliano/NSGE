using NSGE.Domain.Entity.Financeiro;

namespace NSGE.Services.Interfaces.Financeiro
{
    public interface IContasAReceberService
    {
        public List<ContasAReceber> GetAll(ContasAReceberFiltro filtro);
    }
}