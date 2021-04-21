using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Cliente : Base
    {
        public string Nome { get; set; }
        
        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public Conta conta { get; set; }

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
