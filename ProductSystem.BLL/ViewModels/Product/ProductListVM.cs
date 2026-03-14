namespace ProductSystem.BLL.ViewModels
{
    public class ProductListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string CategoryName { get; set; }
        public string? ImageUrl { get; set; }
    }
}