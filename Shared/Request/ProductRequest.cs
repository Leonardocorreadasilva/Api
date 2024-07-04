namespace Shared.Request
{
    public class ProductRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}
