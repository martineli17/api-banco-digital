using System;

namespace Api.Core.DTO.OperacaoDTOs
{
    public class TransferenciaAddRequest : OperacaoBaseAdd
    {
        public Guid IdContaDestino { get; set; }
    }

    public class TransferenciaAddResponse : OperacaoBaseAdd
    {
        public Guid IdContaDestino { get; set; }
    }
}
