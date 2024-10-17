namespace ProductManagementSystem.Infrastructure.Services
{
    public interface IInventoryService
    {
        Task UpdateStock(int productId, int quantity);
    }
}
