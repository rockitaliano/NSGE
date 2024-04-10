using Microsoft.AspNetCore.Mvc.Rendering;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces.Financeiro;

namespace NSGE.Services.Services.Financeiro
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private IContaCorrenteRepository _repository;
        public ContaCorrenteService(IContaCorrenteRepository repository)
        {
            _repository = repository;
        }

        public IList<ContaCorrente> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Banco> PesquisarBancosPorEmpresa(string idEmpresa)
        {
            return _repository.PesquisarBancosPorEmpresa(idEmpresa);
        }

        public IList<ContaCorrente> PesquisarPorEmpresaEBanco(string idEmpresa, string idBanco)
        {
            return _repository.PesquisarPorEmpresaEBanco(idEmpresa, idBanco);
        }

        

        //private bool Existe(ContaCorrente item, bool isUpdate = false)
        //{
        //    var query = 
        //}
    }
}