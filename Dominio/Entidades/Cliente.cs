using Dominio.Entidades.Bases;
using Dominio.Validators.EntidadesValidator;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Cliente : Base
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        [JsonIgnore]
        public Conta Conta { get; set; }
        [JsonIgnore]
        public Cartao Cartao { get; set; }

        public override (bool IsValido, IReadOnlyList<string> Erros) Validar() => 
            base.Validar(new ClienteValidator(), this); 
    }
}
