using MediatR;
using ProductManagementSystem.Application.Notifications;
using ProductManagementSystem.Domain.Interfaces;

namespace ProductManagementSystem.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IMediator mediator)
        : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var productId = await productRepository.AddProductAsync(command.Product);

            await mediator.Publish(new ProductCreatedNotification(command.Product), cancellationToken);

            return productId;
        }
    }
}
