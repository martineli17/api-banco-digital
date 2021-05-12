namespace Api.Core.DTO.OperacaoDTOs
{
    public class SaqueAddRequest : OperacaoBaseAdd
    {
        public string IdentificadorCaixaEletronico { get; set; }
    }

    public class SaqueAddResponse : OperacaoBaseAdd
    {
        public string IdentificadorCaixaEletronico { get; set; }
    }
}
