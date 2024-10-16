using MediatR;
using ProductManagementSystem.Domain.Entities;

namespace ProductManagementSystem.Application.Commands.CreateProduct
{
    public record CreateProductCommand(Product Product) : IRequest<int>;
}
