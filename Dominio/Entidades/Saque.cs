using Dominio.ValuesType;

namespace Dominio.Entidades
{
    public class Saque : OperacaoBase
    {
        public string IdentificadorCaixaEletronico { get; set; }
        public void MovimentarConta() => base.MovimentarConta(EnumEventoMovimentacao.Saque);
    }
}
