namespace ProductManagementSystem.Infrastructure.Services
{
    public class InventoryService : IInventoryService
    {
        public Task UpdateStock(int productId, int quantity)
        {
            Console.WriteLine($"Updating stock for Product ID: {productId} with quantity: {quantity}");
            return Task.CompletedTask;
        }
    }
}
