using MediatR;
using ProductManagementSystem.Domain.Entities;
using ProductManagementSystem.Domain.Interfaces;

namespace ProductManagementSystem.Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        public async Task<List<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            return await productRepository.GetAllProductsAsync();
        }
    }
}
