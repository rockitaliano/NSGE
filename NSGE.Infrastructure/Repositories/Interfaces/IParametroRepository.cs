using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces
{
    public interface IParametroRepository
    {
        public Parametro Filter(string key);

    }
}