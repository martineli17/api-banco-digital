using Dominio.Entidades;
using Dominio.Interfaces.Service.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IContaService : IBaseAddService<Conta>, IBaseUpdateService<Conta>, IBaseQueryService<Conta> ,IBaseRemoveService
    {

    }
}
