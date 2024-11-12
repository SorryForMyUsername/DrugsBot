using System.Reflection;
using System.Text.RegularExpressions;
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
            .Length(2, 150).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^(\w|\s)*$").WithMessage(ValidationMessage.WrongFormat);
        RuleFor(d => d.Manufacturer)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[a-zA-Z -]*$").WithMessage(ValidationMessage.WrongFormat);
        RuleFor(d => d.CountryCodeId)
            .Matches("^[A-Z]{2}$").WithMessage(ValidationMessage.WrongFormat)
            .Must(c => Country.Countries.Any(country => country.Code == c)).WithMessage(ValidationMessage.NotExistValue)
            .When(d => d.CountryCodeId != null);
    }
}