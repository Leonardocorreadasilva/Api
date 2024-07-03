using Api.Domain.Entities;

namespace Api.Domain.Entities
{
    public class CartEntity
    {
        public bool Purchased { get; set; }
        public List<itemsEntity> Items { get; set; } = new List<itemsEntity>();
        public decimal TotalPrice { get; set; }
        public UserEntity User { get; set; }
        public Guid UserId { get; set; }
    }
}
