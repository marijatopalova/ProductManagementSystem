using MediatR;
using ProductManagementSystem.Domain.Interfaces;

namespace ProductManagementSystem.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductByIdAsync(command.Product.Id);

            product.Name = command.Product.Name;
            product.Price = command.Product.Price;

            await productRepository.UpdateProductAsync(product);

            return true;
        }
    }
}
