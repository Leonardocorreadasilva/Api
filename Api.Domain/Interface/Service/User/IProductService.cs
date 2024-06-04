using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interface.Service.User
{
    public interface IProductService
    {
        Task<ProductEntity> Rating(ProductEntity product);
        
    }
}
