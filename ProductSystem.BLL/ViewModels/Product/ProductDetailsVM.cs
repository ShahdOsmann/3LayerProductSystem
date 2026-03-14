
namespace ProductSystem.BLL.ViewModels
{
    public class ProductDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public string? ImageUrl { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}