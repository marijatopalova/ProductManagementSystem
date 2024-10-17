using MediatR;

namespace ProductManagementSystem.Application.Commands.UpdateProduct
{
    public record UpdateProductCommand(int Id, string Name, decimal Price, int StockQuantity) : IRequest<bool>;
}
