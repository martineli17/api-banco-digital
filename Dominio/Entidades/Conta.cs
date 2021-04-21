using Crosscuting.Extensions;
using Dominio.ValuesType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Conta : Base
    {
        public int numeroConta { get; set; }
        public EnumTipoConta tipo { get; set; }
        public double saldo { get; set; }

    }

}
