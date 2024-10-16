using MediatR;
using ProductManagementSystem.Domain.Entities;
using ProductManagementSystem.Domain.Interfaces;

namespace ProductManagementSystem.Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetProductByIdQuery, Product>
    {
        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductByIdAsync(query.Id);

            return product;
        }
    }
}
