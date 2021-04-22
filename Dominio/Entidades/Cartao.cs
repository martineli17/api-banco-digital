using Dominio.Entidades.Bases;
using Dominio.ValuesType;
using System;

namespace Dominio.Entidades
{
    public class Cartao : Base
    {
        public Guid IdCliente { get; set; }
        public string Numero { get; set; }
        public DateTime Vencimento { get; set; }
        public EnumTipoCartao Tipo { get; set; }
        public Cliente Cliente { get; set; }

        public bool IsVencido() => this.Vencimento < DateTime.Now;
    }
}
