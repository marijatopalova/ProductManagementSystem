using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Domain.Entities;
using ProductManagementSystem.Domain.Interfaces;
using ProductManagementSystem.Infrastructure.Persistence;

namespace ProductManagementSystem.Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        public async Task<int> AddProductAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return product.Id;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return false;

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return  await context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
