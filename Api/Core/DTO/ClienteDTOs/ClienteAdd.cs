using System;

namespace Api.Core.DTO.ClienteDTOs
{
    public class ClienteAddRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
    }

    public class ClienteAddResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
    }
}
