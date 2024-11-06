using FluentValidation;
using Domain.Entities;

namespace Domain.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 28).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.CountryCodeId)
            .Matches("");


    }
}