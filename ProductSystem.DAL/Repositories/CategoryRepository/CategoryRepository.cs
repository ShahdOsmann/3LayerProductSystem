
using ProductSystem.DAL.Data.Context;

namespace ProductSystem.DAL
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(AppDbContext context) : base(context) { }
    }
}
