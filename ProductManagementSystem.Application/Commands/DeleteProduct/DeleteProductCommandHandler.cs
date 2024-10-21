using MediatR;
using ProductManagementSystem.Domain.Interfaces;
using ProductManagementSystem.Shared.Exceptions;

namespace ProductManagementSystem.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var isDeleted = await productRepository.DeleteProductAsync(command.Id);

            if (!isDeleted)
            {
                throw new NotFoundException("Product not found or might have been deleted in the meantime");
            }

            return isDeleted;
        }
    }
}
