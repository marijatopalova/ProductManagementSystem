using MediatR;
using ProductManagementSystem.Domain.Entities;

namespace ProductManagementSystem.Application.Commands.UpdateProduct
{
    public record UpdateProductCommand(Product Product) : IRequest<bool>;
}
