using NSGE.Domain.Entity.Operacional;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IManutencaoRepository
    {
        public Task<IList<Manutencao>> GetAll();
    }
}