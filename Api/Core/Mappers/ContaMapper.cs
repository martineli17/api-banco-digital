using Api.Core.DTO.ContaDTOs;
using AutoMapper;
using Dominio.Entidades;

namespace Api.Core.Mappers
{
    public class ContaMapper : Profile
    {
        public ContaMapper()
        {
            CreateMap<ContaAddRequest, Conta>();
            CreateMap<Conta, ContaAddResponse>();
            CreateMap<Conta, ContaUpdateResponse>();
            CreateMap<Conta, ContaGet>()
                .ForMember(dest => dest.NomeCliente, options => options.MapFrom(src => src.Cliente.Nome));
        }
    }
}
