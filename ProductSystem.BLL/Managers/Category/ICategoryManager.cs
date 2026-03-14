 using ProductSystem.BLL.ViewModels;

namespace ProductSystem.BLL.Managers
{
    public interface ICategoryManager
    {
        List<CategoryListVM> GetAll();

        CategoryDetailsVM GetById(int id);

        void Add(CategoryFormVM vm);

        void Update(CategoryFormVM vm);

        void Delete(int id);
    }
}