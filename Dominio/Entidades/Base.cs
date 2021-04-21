using System;

namespace Dominio.Entidades
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        public Base()
        {
            Id = Guid.NewGuid();
        }
    }

    public abstract class BaseProjeto : Base
    {
        public Guid IdProjeto { get; set; }
    }
}
