using MediatR;
using ProductManagementSystem.Application.Notifications;
using ProductManagementSystem.Domain.Entities;
using ProductManagementSystem.Domain.Interfaces;

namespace ProductManagementSystem.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IMediator mediator)
        : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Price = command.Price,
                StockQuantity = command.StockQuantity,
            };

            var productId = await productRepository.AddProductAsync(product);

            await mediator.Publish(new ProductCreatedNotification(product), cancellationToken);

            return productId;
        }
    }
}
