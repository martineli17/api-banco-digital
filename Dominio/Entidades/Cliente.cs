using Dominio.Entidades.Bases;
using Dominio.Validators.EntidadesValidator;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        public void AtualizarDados()
        {
            //Todo
        }
        public void NovoCliente()
        {
            //Todo
        }

        public override (bool IsValido, IReadOnlyList<string> Erros) Validar() => 
            base.Validar(new ClienteValidator(), this); 
    }
}
