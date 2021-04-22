using Dominio.Entidades.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Cliente : Base
    {
        public Guid IdConta { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public Conta Conta { get; set; }
        public Cartao Cartao { get; set; }

        public void AtualizarDados()
        {
            //Todo
        }
        public void NovoCliente()
        {
            //Todo
        }
    }
}
