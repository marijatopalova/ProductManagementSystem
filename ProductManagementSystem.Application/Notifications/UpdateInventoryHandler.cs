using MediatR;
using ProductManagementSystem.Infrastructure.Services;

namespace ProductManagementSystem.Application.Notifications
{
    public class UpdateInventoryHandler(IInventoryService inventoryService)
        : INotificationHandler<ProductCreatedNotification>
    {
        public async Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            await inventoryService.UpdateStock(notification.Product.Id, notification.Product.StockQuantity);
        }
    }
}
