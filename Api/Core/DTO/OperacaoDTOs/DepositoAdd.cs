namespace Api.Core.DTO.OperacaoDTOs
{
    public class DepositoAddRequest : OperacaoBaseAdd
    {
        public string NumeroBoleto { get; set; }
        public string Credenciador { get; set; }
    }

    public class DepositoAddResponse : OperacaoBaseAdd
    {
        public string NumeroBoleto { get; set; }
        public string Credenciador { get; set; }
    }
}
