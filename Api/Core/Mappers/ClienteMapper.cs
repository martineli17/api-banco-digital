using Api.Core.DTO.ClienteDTOs;
using AutoMapper;
using Dominio.Entidades;

namespace Api.Core.Mappers
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<ClienteAddRequest, Cliente>();
            CreateMap<Cliente, ClienteAddResponse>();
        }
    }
}
