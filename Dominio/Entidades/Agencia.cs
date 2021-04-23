using Dominio.Entidades.Bases;
using Dominio.Validators.EntidadesValidator;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Agencia : Base 
    {
        public string Numero { get; set; }

        protected override (bool IsValido, IReadOnlyList<string> Erros) Validar() => base.Validar(new AgenciaValidator(), this);
    }
}
