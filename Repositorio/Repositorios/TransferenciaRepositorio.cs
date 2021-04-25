using Dominio.Entidades;
using Repositorio.Repositorios.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
    public class TransferenciaRepositorio : BaseRepositorio<Transferencia>
    {
        public TransferenciaRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}
