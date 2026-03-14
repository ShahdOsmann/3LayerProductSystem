namespace ProductSystem.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Count { set; get; }

        public string? ImageUrl { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public int CategoryId { get; set; }
       public virtual Category Category { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
