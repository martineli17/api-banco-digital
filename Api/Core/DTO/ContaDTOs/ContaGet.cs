using Dominio.ValuesType;
using System;

namespace Api.Core.DTO.ContaDTOs
{
    public class ContaGet
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string Numero { get; private set; }
        public string NomeCliente { get; private set; }
        public EnumTipoConta Tipo { get; set; }
        public decimal Saldo { get; set; }
        public bool Ativo { get; set; }
    }
}
