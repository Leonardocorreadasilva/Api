using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock {  get; set; }
        public decimal Price { get; set; }
        public AddressEntity Address { get; set; }
        public UserEntity user { get; set; }
        //public ProductCategoryEntity productCategory { get; set; }
    }
}
