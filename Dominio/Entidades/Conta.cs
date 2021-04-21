using Dominio.ValuesType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Conta : Base
    {
        public string NumeroConta { get; set; }

        public EnumTipoConta Tipo { get; set; }

        public double Saldo { get; set; }

        public void AlterarTipo()
        {
            Tipo = Tipo == EnumTipoConta.Corrente ? EnumTipoConta.Poupança : EnumTipoConta.Corrente;  
        }

        public void PagarConta()
        {
            //Todo
        }
        public void SolicitarEmprestimo()
        {
            //Todo
        }
    }
}
