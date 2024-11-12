using System.Text.RegularExpressions;
using FluentValidation;
using Domain.Entities;

namespace Domain.Validators;

public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^([a-zA-Z]|\s)*$").WithMessage(ValidationMessage.WrongFormat);
        RuleFor(d => d.Code)
            .Length(2, 2).WithMessage(ValidationMessage.WrongExactLength) //Не понял как при Length(2) добавить в сообщение требуемую длину.
            .Matches("^[A-Z]*$").WithMessage(ValidationMessage.WrongFormat)
            .When(c => c.Code != null);
    }
}