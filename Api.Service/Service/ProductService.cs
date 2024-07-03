using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Service.Product;
using Shared.Request;

namespace Api.Service.Service
{


    public class ProductService(IRepository<AddressEntity> addressRepository,
        IRepository<ProductEntity> productService,
        IRepository<UserEntity> userService, IRepository<ProductCategoryEntity> category) : IProductService
    {
        public async Task<ProductEntity> Create(ProductRequest produto)
        {

            var user = await userService.SelectAsync(produto.UserId);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            var address = await addressRepository.SelectAsync(produto.AddressId);
            if (address == null)
            {
                throw new Exception("Endereço não encontrado.");
            }

            var productCategory = await category.SelectAsync(produto.ProductCategoryId);

            ProductEntity product = new ProductEntity
            {
                Name = produto.Name,
                Description = produto.Description,
                Price = produto.Price,
                Stock = produto.Stock,
                User = user,
                Address = address,
                ProductCategory = productCategory
            };
            return await productService.InsertAsync(product);
        }

        public async Task<ProductEntity> Edit(ProductEntity product)
        {
            // Verificar se o usuário associado ao produto existe
            var userExists = await userService.SelectAsync(product.User.Id);
            if (userExists == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            // Verificar se o endereço associado ao produto existe
            var addressExists = await addressRepository.SelectAsync(product.Address.Id);
            if (addressExists == null)
            {
                throw new Exception("Endereço não encontrado.");
            }

            // Aqui você pode adicionar validações ou lógicas adicionais antes de atualizar o produto
            return await productService.UpdateAsync(product);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await productService.DeleteAsync(id);
        }



        public async Task<ProductEntity> Get(Guid id)
        {
            return await productService.SelectAsync(id);
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await productService.SelectAsync();
        }


    }
}
