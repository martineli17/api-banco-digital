using Dominio.Entidades;
using Repositorio.Repositorios.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
    public class ContaRepositorio : BaseRepositorio<Conta>
    {
        public ContaRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}
