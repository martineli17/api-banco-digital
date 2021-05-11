using System;

namespace Api.Core.DTO.OperacaoDTOs
{
    public abstract class OperacaoBaseAdd
    {
        public Guid IdConta { get; set; }
        public decimal Valor { get; set; }
    }
}
