using FluentValidation;

namespace ProductManagementSystem.Application.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Product.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.Product.Price)
                .GreaterThan(0)
                .WithMessage("Price should be greater than zero");
        }
    }
}
