using Microsoft.EntityFrameworkCore;
using ProductSystem.DAL;
using ProductSystem.BLL.ViewModels;
using ProductSystem.DAL.Data.Context;

namespace ProductSystem.BLL.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly AppDbContext _context;

        public ProductManager(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductListVM> GetAll()
        {
            return _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductListVM
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    Count = p.Count,
                    CategoryName = p.Category.Name,
                    ImageUrl = p.ImageUrl
                }).ToList();
        }

        public ProductDetailsVM? GetById(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (product == null) return null;

            return new ProductDetailsVM
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Description = product.Description,
                Count = product.Count,
                ImageUrl = product.ImageUrl,
                ExpiryDate = product.ExpiryDate,
                CategoryName = product.Category.Name
            };
        }

        public void Create(ProductFormVM vm)
        {
            var product = new Product
            {
                Title = vm.Title,
                Price = vm.Price,
                Description = vm.Description,
                Count = vm.Count,
                ImageUrl = vm.ImageUrl,
                ExpiryDate = vm.ExpiryDate,
                CategoryId = vm.CategoryId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(ProductFormVM vm)
        {
            var product = _context.Products.Find(vm.Id);
            if (product == null) return;

            product.Title = vm.Title;
            product.Price = vm.Price;
            product.Description = vm.Description;
            product.Count = vm.Count;
            product.ImageUrl = vm.ImageUrl;
            product.ExpiryDate = vm.ExpiryDate;
            product.CategoryId = vm.CategoryId;
            product.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return;

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}