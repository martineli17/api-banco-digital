using Dominio.ValuesType;

namespace Dominio.Entidades
{
    public class Deposito : OperacaoBase
    {
        public string NumeroBoleto { get; set; }
        public string Credenciador { get; set; }
        public Deposito MovimentarConta()
        {
            base.MovimentarConta(EnumEventoMovimentacao.Deposito);
            return this;
        }

        public Deposito Depositar()
        {
            if (this.Movimentacao is null) this.MovimentarConta();
            this.Movimentacao.Conta.Saldo += this.Valor;
            return this;
        }
    }
}
