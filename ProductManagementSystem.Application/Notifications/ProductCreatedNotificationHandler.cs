using MediatR;
using Microsoft.Extensions.Logging;

namespace ProductManagementSystem.Application.Notifications
{
    public class ProductCreatedNotificationHandler(ILogger<ProductCreatedNotificationHandler> logger) 
        : INotificationHandler<ProductCreatedNotification>
    {
        public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Product Created: {notification.Product.Name}");
            return Task.CompletedTask;
        }
    }
}
