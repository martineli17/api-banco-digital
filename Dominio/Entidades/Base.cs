using System;

namespace Dominio.Entidades
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public Base()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }
    }
}
