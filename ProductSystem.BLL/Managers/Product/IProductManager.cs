using ProductSystem.BLL.ViewModels;

namespace ProductSystem.BLL.Managers
{
    public interface IProductManager
    {
        List<ProductListVM> GetAll();
        ProductDetailsVM? GetById(int id);
        void Create(ProductFormVM vm);
        void Update(ProductFormVM vm);
        void Delete(int id);
    }
}