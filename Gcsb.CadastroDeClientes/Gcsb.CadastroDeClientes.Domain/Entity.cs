using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.CadastroDeClientes.Domain
{
    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        [NotMapped]
        public bool IsValid { get; private set; }
        
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return IsValid = ValidationResult.IsValid;
        }

    }
}
