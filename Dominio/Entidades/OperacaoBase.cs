using Dominio.ValuesType;
using System;

namespace Dominio.Entidades
{
    public abstract class OperacaoBase : Base
    {
        public Guid IdConta { get; set; }
        public Guid IdMovimentacao { get; set; }
        public decimal Valor { get; set; }
        public Movimentacao Movimentacao { get; private set; }
        public void MovimentarConta(EnumEventoMovimentacao evento) =>
            this.Movimentacao = new Movimentacao(this.IdConta, evento, this.Valor);
    }
}
