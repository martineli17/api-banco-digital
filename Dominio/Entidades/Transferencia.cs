using Dominio.Entidades.Bases;
using Dominio.Validators.EntidadesValidator;
using Dominio.ValuesType;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Transferencia : OperacaoBase
    {
        public Guid IdContaOrigem { get; set; }
        public DateTime DataAgendamento { get; set; }
        public Conta ContaOrigem { get; set; }
        public Transferencia MovimentarConta()
        {
            base.MovimentarConta(EnumEventoMovimentacao.Transferencia);
            return this;
        }
        public Transferencia Transferir()
        {
            if (this.Movimentacao is null) this.MovimentarConta();
            this.ContaOrigem.Saldo -= this.Valor;
            this.Movimentacao.Conta.Saldo += this.Valor;
            return this;
        }

        protected override (bool IsValido, IReadOnlyList<string> Erros) Validar() => base.Validar(new TransferenciaValidator(), this);
    }
}
