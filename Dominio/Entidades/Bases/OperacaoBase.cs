using Dominio.ValuesType;
using System;

namespace Dominio.Entidades.Bases
{
    public abstract class OperacaoBase : Base
    {
        public Guid IdMovimentacao { get; set; }
        public Movimentacao Movimentacao { get; set; }
        protected void MovimentarConta(EnumEventoMovimentacao evento) =>  Movimentacao.Evento = evento;

        public OperacaoBase()
        {
            Movimentacao = new Movimentacao();
        }
    }
}
