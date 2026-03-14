
namespace ProductSystem.DAL
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllWithCategory(int categoryId);

        Product? GetByIdWithCategory(int productId);

    }
}
