using Dominio.ValuesType;
using System;

namespace Api.Core.DTO.CartaoDTOs
{
    public class CartaoAddRequest
    {
        public Guid IdCliente { get; set; }
        public EnumTipoCartao Tipo { get; set; }
    }

    public class CartaoAddResponse
    {
        public Guid IdCliente { get; set; }
        public string Numero { get; private set; }
        public bool Ativo { get; set; }
        public DateTime Vencimento { get; private set; }
        public EnumTipoCartao Tipo { get; set; }
    }
}
