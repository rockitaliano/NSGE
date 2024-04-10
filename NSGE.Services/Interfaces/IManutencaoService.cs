using NSGE.Domain.Entity.Operacional;

namespace NSGE.Services.Interfaces
{
    public interface IManutencaoService
    {
        public Task<IList<Manutencao>> GetAll();
    }
}