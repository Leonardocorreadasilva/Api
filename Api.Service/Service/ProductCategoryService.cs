using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Service.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Service
{
    public class ProductCategoryService : IProductCategory
    {
        private readonly IRepository<ProductCategoryEntity> _repository;
        private readonly IRepository<ProductEntity> _productRepository;

        public ProductCategoryService(IRepository<ProductCategoryEntity> repository, IRepository<ProductEntity> productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProductCategoryEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ProductCategoryEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ProductCategoryEntity> Post(ProductCategoryEntity category)
        {
            return await _repository.InsertAsync(category);
        }

        public async Task<ProductCategoryEntity> Put(ProductCategoryEntity category)
        {
            return await _repository.UpdateAsync(category);
        }
        public async Task<IEnumerable<ProductEntity>> GetProductsByCategory(Guid categoryId)
        {
            // Supondo que exista um método no repositório para buscar produtos por categoria
            var products = await _productRepository.SelectAsync();
            return products.Where(product => product.ProductCategoryId == categoryId);
        }
    }
}
