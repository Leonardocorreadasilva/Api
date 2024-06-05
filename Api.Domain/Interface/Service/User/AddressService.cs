using Api.Domain.Entities;
using Shared.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interface.Service.User
{
    public interface IAddressService
    {
        Task<AddressEntity> Get(Guid id);
        Task<IEnumerable<AddressEntity>> GetAll();
        Task<AddressEntity> Post(AddressRequest address);
        Task<AddressEntity> Put(AddressRequest address);
        Task<bool> Delete(Guid id);

    }
}
