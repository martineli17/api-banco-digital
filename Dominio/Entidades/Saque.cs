using Dominio.Entidades.Bases;
using Dominio.Validators.EntidadesValidator;
using Dominio.ValuesType;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Saque : OperacaoBase
    {
        public string IdentificadorCaixaEletronico { get; set; }
        public Saque MovimentarConta()
        {
            base.MovimentarConta(EnumEventoMovimentacao.Saque);
            return this;
        }
        public Saque Sacar()
        {
            if (this.Movimentacao is null) this.MovimentarConta();
            this.Movimentacao.Conta.Saldo -= this.Valor;
            return this;
        }

        protected override (bool IsValido, IReadOnlyList<string> Erros) Validar() => base.Validar(new SaqueValidator(), this);
    }
}
