 
using Microsoft.EntityFrameworkCore;
using ProductSystem.DAL.Data.Context;


namespace ProductSystem.DAL
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        { 
        }
        public IEnumerable<Product> GetAllWithCategory(int categoryId)
        {
            return _context.Products.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product? GetByIdWithCategory(int productId)
        {
            return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == productId);
        }
    }
}
