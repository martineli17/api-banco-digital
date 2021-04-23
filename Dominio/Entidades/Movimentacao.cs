using Crosscuting.Extensions;
using Dominio.Entidades.Bases;
using Dominio.ValuesType;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Movimentacao : Base
    {
        private EnumEventoMovimentacao _evento;
        public Guid IdConta { get; set; }
        public EnumEventoMovimentacao Evento 
        { 
            get => _evento; 
            set 
            {
                 _evento = value;
                 DefinirTipo();
            } 
        }
        public EnumTipoMovimentacao Tipo { get; private set; }
        public decimal Valor { get; set; }
        public Conta Conta { get; set; }
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

        protected override (bool IsValido, IReadOnlyList<string> Erros) Validar() => (true, null);
    }
}
