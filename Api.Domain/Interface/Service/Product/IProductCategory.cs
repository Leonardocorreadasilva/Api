using Api.Domain.Entities;
using Shared.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interface.Service.Product
{
    public interface IProductCategory
    {
        Task<ProductCategoryEntity> Post(ProductCategoryEntity category);
        Task<ProductCategoryEntity> Put(ProductCategoryEntity category);
        Task<ProductCategoryEntity> Get(Guid id);
        Task<IEnumerable<ProductCategoryEntity>> GetAll();
        Task<bool> Delete(Guid id);
        Task<IEnumerable<ProductEntity>> GetProductsByCategory(Guid categoryId);
    }
}
