using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interfaces.Services.User;
using Shared.Request;
using Api.Domain.Interface.Service.Address;
using Api.Domain.Interface.Service.Product;

namespace Api.Service.Service
{


    public class ProductService : IProductService
    {

        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<AddressEntity> _addressRepository;
        private readonly IRepository<ProductEntity> _productRepository;
        public ProductService(IRepository<UserEntity> userRepository, IRepository<AddressEntity> addressRepository, IRepository<ProductEntity> productService )
        {
            _productRepository = productService;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public async Task<ProductEntity> Create(ProductRequest produto)  
        {
            ProductEntity product = new ProductEntity();
            product.Name = produto.Name;
            product.Description = produto.Description;
            product.Price = produto.Price;
            product.Stock = produto.Stock;
            product.UserId = produto.UserId;
            product.AddressId = produto.AddressId;
            return await _productRepository.InsertAsync(product);
        }


        Task<ProductEntity> IProductService.Edit(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
