using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Entidades.Bases
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public Base()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }

        public abstract (bool IsValido, IReadOnlyList<string> Erros) Validar();

        protected (bool IsValido, IReadOnlyList<string> Erros) Validar<TObject>(AbstractValidator<TObject> validator, TObject dados) where TObject : Base
        {
            if (dados is null)
                return (false, new List<string> { "Dados inválidos" });
            var erros = new List<string>();
            var validacao = validator.Validate(dados);
            if (!validacao.IsValid)
                erros.AddRange(validacao.Errors.Select(x => x.ErrorMessage).ToList());
            return (validacao.IsValid, erros);
        }
    }
}
