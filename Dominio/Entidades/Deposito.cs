using Dominio.ValuesType;

namespace Dominio.Entidades
{
    public class Deposito : OperacaoBase
    {
        public string NumeroBoleto { get; set; }
        public string Credenciador { get; set; }
        public void MovimentarConta() => base.MovimentarConta(EnumEventoMovimentacao.Deposito);
    }
}
