using Dominio.Entidades.Bases;
using Dominio.ValuesType;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Conta : Base
    {
        public Guid IdCliente { get; set; }
        public string Numero { get; set; }
        public EnumTipoConta Tipo { get; set; }
        public decimal Saldo { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Movimentacao> Movimentacoes { get; set; }

        protected override (bool IsValido, IReadOnlyList<string> Erros) Validar()
        {
            throw new NotImplementedException();
        }
    }

}
