using System.ComponentModel.DataAnnotations;

namespace Dominio.ValuesType
{
    public enum EnumEventoMovimentacao
    {
        [Display(ShortName = "D")]
        Saque = 1,
        [Display(ShortName = "D")]
        Transferencia = 2,
        [Display(ShortName = "C")]
        Deposito = 4,
    }
}
