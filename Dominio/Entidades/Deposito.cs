using Dominio.Entidades.Bases;
using Dominio.Validators.EntidadesValidator;
using Dominio.ValuesType;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Deposito : OperacaoBase
    {
        public string NumeroBoleto { get; set; }
        public string Credenciador { get; set; }
        public Deposito()
        {
            base.MovimentarConta(EnumEventoMovimentacao.Deposito);
        }
        public Deposito MovimentarConta()
        {
            base.MovimentarConta(EnumEventoMovimentacao.Deposito);
            return this;
        }

        public Deposito Depositar()
        {
            if (this.Movimentacao is null) this.MovimentarConta();
            this.Movimentacao.Conta.Saldo += this.Movimentacao.Valor;
            return this;
        }

        public override (bool IsValido, IReadOnlyList<string> Erros) Validar() => base.Validar(new DepositoValidator(), this);
    }
}
