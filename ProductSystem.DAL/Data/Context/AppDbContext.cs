using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 
namespace ProductSystem.DAL.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }  
        public override int SaveChanges()
        {
            AuditLog();
            return base.SaveChanges();
        }
        private void AuditLog()
        {
            var dateTime = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = dateTime;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = dateTime;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var createdDate = new DateTime(2026, 3, 1, 10, 30, 0);

            List<Product> products = new List<Product>()
            {
                new Product(){Id=1,Title="Iphone 14 Pro Max",Price=1500,Description="Apple'ın en yeni telefonu",ExpiryDate=new DateOnly(2026, 12, 31),Count=10,CategoryId=1, CreatedAt=createdDate, UpdatedAt=createdDate},
                new Product(){Id=2,Title="Samsung Galaxy S23 Ultra",Price=1400,Description="Samsung'un en yeni telefonu",ExpiryDate=new DateOnly(2026, 12, 31),Count=15,CategoryId=1, CreatedAt=createdDate, UpdatedAt=createdDate},
                new Product(){Id=3,Title="Xiaomi Mi 12 Pro",Price=1200,Description="Xiaomi'nin en yeni telefonu",Count=20,ExpiryDate=new DateOnly(2026, 12, 31),CategoryId=1, CreatedAt=createdDate, UpdatedAt=createdDate},
                new Product(){Id=4,Title="Sony WH-1000XM4",Price=350,Description="Sony'nin en iyi kablosuz kulaklığı",ExpiryDate=new DateOnly(2026, 12, 31),Count=30,CategoryId=2, CreatedAt=createdDate, UpdatedAt=createdDate},
                new Product(){Id=5,Title="Bose QuietComfort 35 II",Price=300,Description="Bose'un en iyi kablosuz kulaklığı",ExpiryDate=new DateOnly(2026, 12, 31),Count=25,CategoryId=2, CreatedAt=createdDate, UpdatedAt=createdDate},
                new Product(){Id=6,Title="Apple AirPods Pro",Price=250,Description="Apple'ın en iyi kablosuz kulaklığı",ExpiryDate=new DateOnly(2026, 12, 31),Count=40,CategoryId=2, CreatedAt=createdDate, UpdatedAt=createdDate}
            };
            List<Category> categories = new List<Category>()
            {
                new Category(){Id=1,Name="Electronics"},
                new Category(){Id=2,Name="phone"} 
            };

            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Category>().HasData(categories); 
    
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }
         
        public virtual DbSet<Product> Products => Set<Product>();
        public virtual DbSet<Category> Categories => Set<Category>();

    }
}
