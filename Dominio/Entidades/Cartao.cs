using Dominio.Entidades.Bases;
using Dominio.ValuesType;
using System;
using Crosscuting.Extensions;
using System.Collections.Generic;
using Dominio.Validators.EntidadesValidator;

namespace Dominio.Entidades
{
    public class Cartao : Base
    {
        public Guid IdCliente { get; set; }
        public string Numero { get; private set; }
        public bool Ativo { get; set; }
        public DateTime Vencimento { get; private set; }
        public EnumTipoCartao Tipo { get; set; }
        public Cliente Cliente { get; set; }
        public Cartao()
        {
            Numero = GerarNumero();
            Vencimento = DateTime.Now.AddYears(4);
        }
        public bool IsVencido() => this.Vencimento < DateTime.Now;
        public Cartao Ativar()
        {
            this.Ativo = true;
            return this;
        }
        public Cartao Desativar()
        {
            this.Ativo = false;
            return this;
        }

        public string GerarNumero() =>  
                        $"{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}" +
                        $" {Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}" +
                        $" {Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}";

        public override (bool IsValido, IReadOnlyList<string> Erros) Validar() =>
            base.Validar(new CartaoValidator(), this);

        public Cartao MudarTipo(EnumTipoCartao tipo) =>
            tipo switch
            {
                EnumTipoCartao.Credito => this.AtivarCredito(),
                EnumTipoCartao.Debito => this.AtivarDebito(),
                EnumTipoCartao.Debito_Credito => this.AtivarCreditoDebito(),
                _ => throw new ArgumentOutOfRangeException("Tipo de cartão inválido")
            };

        public Cartao AtivarCredito()
        {
            this.Tipo = EnumTipoCartao.Credito;
            return this;
        }
        public Cartao AtivarDebito()
        {
            this.Tipo = EnumTipoCartao.Debito;
            return this;
        }

        public Cartao AtivarCreditoDebito()
        {
            this.Tipo = EnumTipoCartao.Debito_Credito;
            return this;
        }
    }
}
