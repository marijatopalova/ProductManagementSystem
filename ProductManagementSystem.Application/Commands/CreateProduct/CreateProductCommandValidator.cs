﻿using FluentValidation;

namespace ProductManagementSystem.Application.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price should be greater than zero");
        }
    }
}
