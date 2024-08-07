﻿namespace Api.Domain.Entities
{
    public class itemsEntity: BaseEntity
    {
        public ProductEntity Product { get; set; }
        public Guid ProductId { get; set; }
        public UserEntity User { get; set; }
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public bool Purchased { get; set; }
    }
}
