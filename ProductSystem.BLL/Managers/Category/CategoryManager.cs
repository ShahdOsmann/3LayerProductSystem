 using ProductSystem.BLL.ViewModels;
using ProductSystem.DAL;
using ProductSystem.DAL.Data.Context; 
 
namespace ProductSystem.BLL.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly AppDbContext context;

        public CategoryManager(AppDbContext context)
        {
            this.context = context;
        }

        public List<CategoryListVM> GetAll()
        {
            return context.Categories
                .Select(c => new CategoryListVM
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
        }

        public CategoryDetailsVM GetById(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
                return null;

            return new CategoryDetailsVM
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public void Add(CategoryFormVM vm)
        {
            Category category = new Category
            {
                Name = vm.Name
            };

            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Update(CategoryFormVM vm)
        {
            var category = context.Categories.Find(vm.Id);

            if (category == null) return;

            category.Name = vm.Name;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null) return;

            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}