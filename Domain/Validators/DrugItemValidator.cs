using FluentValidation;
using Domain.Entities;

namespace Domain.Validators;

public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(d => d.Cost)
            .GreaterThan(0).WithMessage(ValidationMessage.LessThanNeed)
            .PrecisionScale(15, 2, true).WithMessage(ValidationMessage.WrongScale);
        RuleFor(d => d.Count)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.LessThanNeed)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.GreaterThanNeed);
    }
}