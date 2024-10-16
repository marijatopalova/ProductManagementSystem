using MediatR;
using ProductManagementSystem.Domain.Entities;

namespace ProductManagementSystem.Application.Notifications
{
    public record ProductCreatedNotification(Product Product) : INotification;
}
