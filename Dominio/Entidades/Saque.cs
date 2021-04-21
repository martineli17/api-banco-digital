using Dominio.ValuesType;

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
    }
}
