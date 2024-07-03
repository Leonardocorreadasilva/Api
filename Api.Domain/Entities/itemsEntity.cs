namespace Api.Domain.Entities
{
    public class itemsEntity
    {
        public ProductEntity Product { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public bool Purchased { get; set; }
    }
}
