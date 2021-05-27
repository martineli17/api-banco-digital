using Api.Core.DTO.ContaDTOs;
using AutoMapper;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core.Mappers
{
    public class ContaMapper : Profile
    {
        public ContaMapper()
        {
            CreateMap<ContaAddRequest, Conta>();
            CreateMap<Conta, ContaAddResponse>();
            CreateMap<Conta, ContaUpdateResponse>();
            CreateMap<ContaUpdateTipoRequest, Conta>();
        }
    }
}
