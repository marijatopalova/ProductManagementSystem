using MediatR;
using ProductManagementSystem.Domain.Interfaces;

namespace ProductManagementSystem.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var productId = await productRepository.AddProductAsync(command.Product);

            return productId;
        }
    }
}
