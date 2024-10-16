using MediatR;
using ProductManagementSystem.Domain.Entities;

namespace ProductManagementSystem.Application.Queries.GetAllProducts
{
    public record GetAllProductsQuery() : IRequest<List<Product>>;
}
