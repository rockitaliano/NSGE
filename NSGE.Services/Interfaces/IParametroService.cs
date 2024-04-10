using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface IParametroService
    {
        public string Filter(ParametroEnum key);
        string CarregarPorNome(ParametroEnum key);
    }
}