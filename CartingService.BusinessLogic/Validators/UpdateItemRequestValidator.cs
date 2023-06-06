using CartingService.BusinessLogic.Handlers;
using FluentValidation;

namespace CartingService.BusinessLogic.Validators;

public class UpdateItemRequestValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemRequestValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
        RuleFor(e => e.Price).GreaterThan(0);
    }
}