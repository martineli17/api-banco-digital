namespace Dominio.Validators.MessagensValidator
{
    public static class MensagemValidator
    {
        public static string NaoMaiorOuIgual(string campo) => campo + " não pode ser maior ou igual a {ComparisonValue}. " +
                                                            "Valor informado foi {PropertyValue}.";
        public static string NaoMenorOuIgual(string campo) => campo + " não pode ser menor ou igual a {ComparisonValue}. " +
                                                            "Valor informado foi {PropertyValue}.";
        public static string NaoMaior(string campo) => campo + " não pode ser maior que {ComparisonValue}. " +
                                                            "Valor informado foi {PropertyValue}.";
        public static string NaoMenor(string campo) => campo + " não pode ser menor que {ComparisonValue}. " +
                                                            "Valor informado foi {PropertyValue}.";
        public static string NaoNuloOuVazio(string campo) => campo + " precisa ser informado.";
        public static string TamanhoMaximo(string campo) => campo + " ter no máximo {MaxLength}.";

        public static string ErroNoProcesso = "Ocorreu um erro interno ao realizar a operação (001).";
        public static string IsEnum(string campo) => campo + " contém valor não identificado.";
        public static string RegistroNaoEncontrado(string campo) => $"{campo} não encontrado.";
    }
}
