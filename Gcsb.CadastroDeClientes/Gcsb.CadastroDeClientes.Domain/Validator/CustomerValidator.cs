using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Domain.Validator
{
    public class CustomerValidator : AbstractValidator<Customer.Customer>
    {
        public CustomerValidator()
        {
            RuleFor(r => r.Id)
                .NotNull()
                .NotEqual(new Guid());

            RuleFor(r => r.Nome)
                .NotNull()
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(r => r.Documento)
                .NotNull()
                .GreaterThan(0);

            RuleFor(r => r.Endereco)
                .NotNull()
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(r => r.DataDeNascimento)
                .NotNull()
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(r => r.DataDoCadastro)
                .NotNull()
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(r => r.ClienteAtivo)
                .NotNull();

        }
    }
}
