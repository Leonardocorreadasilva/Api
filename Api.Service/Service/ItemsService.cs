using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Service.Product;
using Shared.Request;
using System;
using System.Threading.Tasks;

namespace Api.Service.Service
{
    public class ItemsService : IItemsService
    {
        private readonly IRepository<itemsEntity> _itemsRepository;
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly IRepository<UserEntity> _userRepository;
        public ItemsService(IRepository<itemsEntity> itemsRepository, IRepository<ProductEntity> productRepository, IRepository<UserEntity> userRepository)
        {
            _itemsRepository = itemsRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }



        public async Task<itemsEntity> Purchase(ItemsRequest item)
        {
            // Verifica se o produto existe
            var user = await _userRepository.SelectAsync(item.UserId);
            var product = await _productRepository.SelectAsync(item.ProductId);
            if (product == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            // Verifica se há estoque suficiente
            if (product.Stock < item.Quantity)
            {
                throw new ArgumentException("Quantidade solicitada não disponível em estoque.");
            }

            product.Stock -= item.Quantity;
            await _productRepository.UpdateAsync(product);

            // Cria uma nova entidade itemsEntity a partir do ItemsRequest
            var newItem = new itemsEntity
            {
                ProductId = item.ProductId,
                UserId = item.UserId,
                Quantity = item.Quantity,
                Purchased = item.Purchased
            };

            // Insere a nova entidade no repositório
            await _itemsRepository.InsertAsync(newItem);

            // Retorna a entidade inserida
            return newItem;
        }

        public async Task<itemsEntity> Get(Guid id)
        {
            // Seleciona a entidade pelo ID
            var item = await _itemsRepository.SelectAsync(id);
            if (item == null)
            {
                throw new ArgumentException("Item não encontrado.");
            }
            return item;
        }

        public async Task<IEnumerable<itemsEntity>> GetAll()
        {
            // Retorna todos os itens
            return await _itemsRepository.SelectAsync();
        }
    }
}
