﻿using NSGE.Domain.Entity.Associative;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces
{
    public interface ILocalService
    {
        public Task<IList<Local>> GetAll();
        public Task<IList<Local>> GetByFilter(string descricao);
        public Task<Local> Load(string id);
        public void Delete(string id);
        public void Insert(Local entity);
        public Endereco Enderecos(Local local);
        public List<LocalEvento> RecuperarHospedagens(string eventoId);
    }
}