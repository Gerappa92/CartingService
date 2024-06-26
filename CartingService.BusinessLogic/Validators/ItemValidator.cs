﻿using CartingService.BusinessLogic.Models;
using FluentValidation;

namespace CartingService.BusinessLogic.Validators;

public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
        RuleFor(i => i.Name).NotEmpty();
        RuleFor(i => i.Price).GreaterThan(0);
    }
}