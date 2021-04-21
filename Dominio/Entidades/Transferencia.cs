using Dominio.ValuesType;
using System;

namespace Dominio.Entidades
{
    public class Transferencia : OperacaoBase
    {
        public Guid IdContaOrigem { get; set; }
        public DateTime DataAgendamento { get; set; }
        public void MovimentarConta() => base.MovimentarConta(EnumEventoMovimentacao.Transferencia);
    }
}
