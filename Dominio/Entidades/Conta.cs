using Crosscuting.Extensions;
using Dominio.Entidades.Bases;
using Dominio.Validators.EntidadesValidator;
using Dominio.ValuesType;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Conta : Base
    {
        public Guid IdCliente { get; set; }
        public string Numero { get; private set; }
        public EnumTipoConta Tipo { get; set; }
        public decimal Saldo { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        [JsonIgnore]
        public ICollection<Movimentacao> Movimentacoes { get; set; }
        [JsonIgnore]
        public ICollection<Transferencia> TransferenciasRecebidas { get; set; }
        public override (bool IsValido, IReadOnlyList<string> Erros) Validar() => base.Validar(new ContaValidator(), this);
        public Conta()
        {
            Numero = GerarNumero();
        }
        public string GerarNumero() =>
                        $"{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}" +
                        $"{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}" +
                        $"{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}-{Numero.RandonsNumbers()}";
    }

}
