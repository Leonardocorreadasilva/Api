using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class CartEntity
    {
        public List<ProductEntity> Products { get; set; }
        public UserEntity User { get; set; }
    }
}
