using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Shared.Request;

namespace Api.Domain.Interface.Service.Product
{
    public interface IItemsService
    {
        Task<itemsEntity> Get(Guid id);
        Task<IEnumerable<itemsEntity>> GetAll();
        Task<itemsEntity> Purchase(ItemsRequest produto);
    }
}
