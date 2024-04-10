using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Entity;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IContasAReceberRepository
    {
        public List<ContasAReceber> GetAll(ContasAReceberFiltro filtro);
        public List<Status> ListarPorTipo(string tipo);
    }
}