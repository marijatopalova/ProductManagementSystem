using MediatR;

namespace ProductManagementSystem.Application.Commands.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest<bool>;
}
