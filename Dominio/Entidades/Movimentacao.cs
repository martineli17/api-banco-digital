using Crosscuting.Extensions;
using Dominio.ValuesType;
using System;

namespace Dominio.Entidades
{
    public class Movimentacao : Base
    {
        public Guid IdConta { get; set; }
        public EnumEventoMovimentacao Evento { get; set; }
        public EnumTipoMovimentacao Tipo { get; private set; }
        public decimal Valor { get; set; }
        //public Conta Conta { get; set; } inserir posteriormente quando a classe Conta for criada
        public Movimentacao(Guid idConta, EnumEventoMovimentacao evento, decimal valor)
        {
            IdConta = idConta;
            Evento = evento;
            Valor = valor;
        }
        public Movimentacao DefinirTipo()
        {
            this.Tipo = this.Evento.ShortName() == "C" ? EnumTipoMovimentacao.Credito : EnumTipoMovimentacao.Debito;
            return this;
        }

    }
}
