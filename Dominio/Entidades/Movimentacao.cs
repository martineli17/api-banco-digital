using Crosscuting.Extensions;
using Dominio.ValuesType;
using System;

namespace Dominio.Entidades
{
    public class Movimentacao : Base
    {
        public Guid IdConta { get; set; }
        public EnumEventoMovimentacao Evento { get; set; }
        public EnumTipoMovimentacao Tipo { get; set; }
        public decimal Valor { get; set; }
        //public Conta Conta { get; set; } inserir posteriormente quando a classe Conta for criada

        public Movimentacao DefinirTipo()
        {
            this.Tipo = this.Evento.ShortName() == "C" ? EnumTipoMovimentacao.Credito : EnumTipoMovimentacao.Debito;
            return this;
        }

        public bool ValorValido() => this.Valor >= 0;
    }
}
