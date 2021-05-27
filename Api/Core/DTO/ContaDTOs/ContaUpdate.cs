using Dominio.ValuesType;
using System;

namespace Api.Core.DTO.ContaDTOs
{
    public class ContaUpdateTipoRequest
    {
        public EnumTipoConta Tipo { get; set; }
    }

    public class ContaUpdateAtivoRequest
    {
        public bool Ativo { get; set; }
    }

    public class ContaUpdateResponse
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string Numero { get; set; }
        public EnumTipoConta Tipo { get; set; }
        public decimal Saldo { get; set; }
        public bool Ativo { get; set; }
    }
}
