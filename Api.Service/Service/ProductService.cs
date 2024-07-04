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

        public async Task<ProductEntity> Edit(ProductRequest productRequest)
        {
            // Verificar se o produto existe
            var productToUpdate = await productService.SelectAsync(productRequest.Id);
            if (productToUpdate == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            // Verificar se o usuário associado ao produto existe
            var userExists = await userService.SelectAsync(productRequest.UserId);
            if (userExists == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            // Verificar se o endereço associado ao produto existe
            var addressExists = await addressRepository.SelectAsync(productRequest.AddressId);
            if (addressExists == null)
            {
                throw new Exception("Endereço não encontrado.");
            }

            // Verificar se a categoria do produto existe
            var categoryExists = await category.SelectAsync(productRequest.ProductCategoryId);
            if (categoryExists == null)
            {
                throw new Exception("Categoria do produto não encontrada.");
            }

            // Atualizar as propriedades do produto
            productToUpdate.Name = productRequest.Name;
            productToUpdate.Description = productRequest.Description;
            productToUpdate.Price = productRequest.Price;
            productToUpdate.Stock = productRequest.Stock;
            productToUpdate.User = userExists;
            productToUpdate.Address = addressExists;
            productToUpdate.ProductCategory = categoryExists;

            // Aqui você pode adicionar validações ou lógicas adicionais antes de atualizar o produto

            // Atualizar o produto no banco de dados
            return await productService.UpdateAsync(productToUpdate);
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
