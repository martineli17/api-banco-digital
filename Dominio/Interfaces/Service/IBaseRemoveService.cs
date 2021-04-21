using System;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IBaseRemoveService
    {
         Task<bool> RemoveAsync(Guid id);
    }
}
