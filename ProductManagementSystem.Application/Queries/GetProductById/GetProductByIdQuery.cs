using MediatR;
using ProductManagementSystem.Domain.Entities;

namespace ProductManagementSystem.Application.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
