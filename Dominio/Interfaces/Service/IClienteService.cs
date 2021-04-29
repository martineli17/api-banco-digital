using Dominio.Entidades;
using Dominio.Interfaces.Service.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Service
{
    public interface IClienteService : IBaseAddService<Cliente>, IBaseQueryService<Cliente>, IBaseUpdateService<Cliente>, IBaseRemoveService
    {
    }
}
