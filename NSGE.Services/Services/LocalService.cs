using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NSGE.CrossCutting.CustomException;
using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class LocalService : ILocalService
    {
        private readonly ILocalRepository _repository;
        public LocalService(ILocalRepository repository)
        {
            _repository = repository;
        }

        public void Delete(string id)
        {
            try
            {
                _repository.Delete(id);               
            }
            catch (DbUpdateException)
            {
                // caso de erro na hora de excluir é pq o local está sendo usado em algum Evento                
                throw new NSGECustomException("Este Local não pode ser excluído pois está em uso.");
            }
        }

        public Endereco Enderecos(Local local)
        {
           //local.Enderecos = _repository.Enderecos(local.Enderecos);
            return null;
        }

        public async Task<IList<Local>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Task<IList<Local>> GetByFilter(string descricao)
        {
            return _repository.GetByFilter(descricao);
        }

        public void Insert(Local entity)
        {
            _repository.Insert(entity);
        }

        public async Task<Local> Load(string id)
        {
            var result = await _repository.Load(id);            
            return result;
        }

        public List<LocalEvento> RecuperarHospedagens(string eventoId)
        {
            return _repository.RecuperarHospedagens(eventoId);
        }
    }
}