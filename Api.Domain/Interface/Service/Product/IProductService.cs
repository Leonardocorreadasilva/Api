using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Shared.Request;

namespace Api.Domain.Interface.Service.Product
{
    public interface IProductService
    {
        //Task<ProductEntity> Rating(ProductEntity product);
        Task<ProductEntity> Create(ProductRequest produto);
        Task<ProductEntity> Edit(ProductEntity product);
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<bool> Delete(Guid id);

    }
}
