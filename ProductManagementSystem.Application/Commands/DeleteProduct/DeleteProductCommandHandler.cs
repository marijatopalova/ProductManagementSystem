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

            if (!isDeleted)
            {
                throw new Exception("Product not found");
            }

            return isDeleted;
        }
    }
}
