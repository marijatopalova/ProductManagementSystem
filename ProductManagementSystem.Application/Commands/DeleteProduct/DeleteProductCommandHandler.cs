using MediatR;
using ProductManagementSystem.Domain.Interfaces;

namespace ProductManagementSystem.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var isDeleted = await productRepository.DeleteProductAsync(command.Id);

            return isDeleted;
        }
    }
}
