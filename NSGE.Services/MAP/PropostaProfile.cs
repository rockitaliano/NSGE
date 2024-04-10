using AutoMapper;
using NSGE.Domain.Dtos.CheckList;
using NSGE.Domain.Entity.Propostas;
using NSGE.Domain.Entity.Propostas.Dtos;

namespace NSGE.Services.MAP
{
    public class PropostaProfile : Profile
    {
        public PropostaProfile()
        {
            CreateMap<Proposta, PropostaDTO>();
            CreateMap<PropostaDTO, Proposta>();
            CreateMap<CheckListGrid, CheckListFiltro>();
            CreateMap<CheckListFiltro, CheckListGrid>();
        }
    }
}