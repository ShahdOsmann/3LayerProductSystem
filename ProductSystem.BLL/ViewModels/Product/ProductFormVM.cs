 
namespace ProductSystem.BLL.ViewModels
{
    public class ProductFormVM
    {
        public int? Id { get; set; }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }

        public DateOnly ExpiryDate { get; set; }

        public int CategoryId { get; set; }

        // For showing existing image
        public string? ImageUrl { get; set; }

        // For uploading new image
 
        public List<CategoryListVM>? Categories { get; set; }
    }
}