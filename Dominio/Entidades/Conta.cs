using Dominio.Entidades.Bases;
using Dominio.ValuesType;

namespace Dominio.Entidades
{
    public class Conta : Base
    {
        public string Numero { get; set; }
        public EnumTipoConta Tipo { get; set; }
        public decimal Saldo { get; set; }

    }

}
