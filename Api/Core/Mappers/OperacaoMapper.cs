using Api.Core.DTO.OperacaoDTOs;
using AutoMapper;
using Dominio.Entidades;

namespace Api.Core.Mappers
{
    public class OperacaoMapper : Profile
    {
        public OperacaoMapper()
        {
            CreateMap<Transferencia, TransferenciaAddResponse>()
                .ForMember(dest => dest.Valor, options => options.MapFrom(src => src.Movimentacao.Valor))
                .ForMember(dest => dest.IdConta, options => options.MapFrom(src => src.Movimentacao.IdConta));
            CreateMap<TransferenciaAddRequest, Transferencia>()
                .ForPath(dest => dest.Movimentacao.Valor, options => options.MapFrom(src => src.Valor))
                .ForPath(dest => dest.Movimentacao.IdConta, options => options.MapFrom(src => src.IdConta));

            CreateMap<Deposito, DepositoAddResponse>()
                .ForPath(dest => dest.Valor, options => options.MapFrom(src => src.Movimentacao.Valor))
                .ForPath(dest => dest.IdConta, options => options.MapFrom(src => src.Movimentacao.IdConta));
            CreateMap<DepositoAddRequest, Deposito>()
                .ForPath(dest => dest.Movimentacao.Valor, options => options.MapFrom(src => src.Valor))
                .ForPath(dest => dest.Movimentacao.IdConta, options => options.MapFrom(src => src.IdConta));

            CreateMap<Saque, SaqueAddResponse>()
                .ForPath(dest => dest.Valor, options => options.MapFrom(src => src.Movimentacao.Valor))
                .ForPath(dest => dest.IdConta, options => options.MapFrom(src => src.Movimentacao.IdConta));
            CreateMap<SaqueAddRequest, Saque>()
                .ForPath(dest => dest.Movimentacao.Valor, options => options.MapFrom(src => src.Valor))
                .ForPath(dest => dest.Movimentacao.IdConta, options => options.MapFrom(src => src.IdConta));
        }
    }
}
