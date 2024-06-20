using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Service.Product;
using Shared.Request;

namespace Api.Service.Service
{


    public class ProductService(IRepository<UserEntity> userRepository, IRepository<AddressEntity> addressRepository, IRepository<ProductEntity> productService, IRepository<UserEntity> userService) : IProductService
    {
        public async Task<ProductEntity> Create(ProductRequest produto)  
        {

            var user = await userService.SelectAsync(produto.UserId);
            var address = await addressRepository.SelectAsync(produto.AddressId);

            ProductEntity product = new ProductEntity();
            product.Name = produto.Name;
            product.Description = produto.Description;
            product.Price = produto.Price;
            product.Stock = produto.Stock;
            product.user = user;
            product.Address = address;
            return await productService.InsertAsync(product);
        }

        Task<bool> IProductService.Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<ProductEntity> IProductService.Edit(ProductEntity product)
        {
            throw new NotImplementedException();
        }

        Task<UserEntity> IProductService.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<UserEntity>> IProductService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
