using ProductManagementSystem.Domain.Entities;

namespace ProductManagementSystem.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
