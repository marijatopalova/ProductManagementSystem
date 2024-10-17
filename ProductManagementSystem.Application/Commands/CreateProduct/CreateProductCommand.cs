using MediatR;

namespace ProductManagementSystem.Application.Commands.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price, int StockQuantity) : IRequest<int>;
}
