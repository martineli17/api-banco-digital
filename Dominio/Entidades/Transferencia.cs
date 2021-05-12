using Dominio.Entidades.Bases;
using Dominio.Validators.EntidadesValidator;
using Dominio.ValuesType;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Transferencia : OperacaoBase
    {
        public Guid IdContaDestino { get; set; }
        public Conta ContaDestino { get; set; }
        public Transferencia()
        {
            base.MovimentarConta(EnumEventoMovimentacao.Transferencia);
        }
        public Transferencia MovimentarConta()
        {
            base.MovimentarConta(EnumEventoMovimentacao.Transferencia);
            return this;
        }
        public Transferencia Transferir()
        {
            if (this.Movimentacao is null) this.MovimentarConta();
            this.ContaDestino.Saldo += this.Movimentacao.Valor;
            this.Movimentacao.Conta.Saldo -= this.Movimentacao.Valor;
            return this;
        }

        public override (bool IsValido, IReadOnlyList<string> Erros) Validar() => base.Validar(new TransferenciaValidator(), this);
    }
}
