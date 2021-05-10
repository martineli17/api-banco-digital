using Api.Core.DTO.CartaoDTOs;
using AutoMapper;
using Dominio.Entidades;

namespace Api.Core.Mappers
{
    public class CartaoMapper : Profile
    {
        public CartaoMapper()
        {
            CreateMap<CartaoAddRequest, Cartao>();
            CreateMap<Cartao, CartaoAddResponse>();
        }
    }
}
