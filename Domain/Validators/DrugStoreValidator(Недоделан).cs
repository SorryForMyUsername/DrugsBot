using FluentValidation;
using Domain.Entities;

namespace Domain.Validators;

public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
        RuleFor(d => d.DrugNetwork)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.Number)
            .GreaterThan(0).WithMessage(ValidationMessage.LessThanNeed);
        RuleFor(d => d)
            .Must(d => d.Network.DrugStores.All(s => s.Number != d.Number))
            .WithName(d => nameof(d.Number))
            .WithMessage(ValidationMessage.NotUnique);
        //RuleFor(d => d.Address)
           //Не реализовал
    }
}