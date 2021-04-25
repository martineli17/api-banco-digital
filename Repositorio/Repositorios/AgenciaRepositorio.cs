using Dominio.Entidades;
using Repositorio.Repositorios.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
    public class AgenciaRepositorio : BaseRepositorio<Agencia>
    {
        public AgenciaRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}
