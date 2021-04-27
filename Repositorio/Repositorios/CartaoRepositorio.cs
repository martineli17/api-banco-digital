using Dominio.Entidades;
using Dominio.Entidades.Bases;
using Repositorio.Repositorios.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
    public class CartaoRepositorio : BaseRepositorio<Conta>
    {
        public CartaoRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}
