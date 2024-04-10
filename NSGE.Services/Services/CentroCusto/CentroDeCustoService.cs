using NSGE.CrossCutting.CustomException;
using NSGE.CrossCutting.CustomGrid;
using NSGE.Domain.Entity;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services.CentroCusto
{
    public class CentroDeCustoService : ICentroDeCustoService
    {
        private const string ERRO_DUPLICADO = "Já existe um centro de custo com esses dados.";
        private readonly ICentroDeCustoRepository _repository;

        public CentroDeCustoService(ICentroDeCustoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CentroDeCusto> Grid(CentroDeCusto filtro)
        {
            return _repository.Grid(filtro);            
        }

        public void Insert(CentroDeCusto item)
        {
            if (Existe(item))
                throw new NSGECustomException(ERRO_DUPLICADO);

            _repository.Insert(item);
        }

        //public bool Existe(CentroDeCusto item)
        //{
        //    var query = _repository.Grid(item);
        //    if (query != null)
        //        return query.Any();
        //    return false;
        //}

        public void Update(CentroDeCusto item)
        {
            if (Existe(item))
                throw new NSGECustomException(ERRO_DUPLICADO);

            _repository.Update(item);
        }

        public void Delete(string id)
        {
            var centroCusto = new CentroDeCusto();
            centroCusto.Id = id;

            if (Existe(centroCusto))
                throw new NSGECustomException(ERRO_DUPLICADO);

            _repository.Delete(id);
        }

        public bool Existe(CentroDeCusto item)
        {
            return _repository.Existe(item);
        }

        public CentroDeCusto GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}