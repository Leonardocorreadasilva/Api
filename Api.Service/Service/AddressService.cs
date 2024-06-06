using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Service.User;
using Api.Domain.Interfaces.Services.User;
using Shared.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Service
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<AddressEntity> _addressRepository;
        public AddressService(IRepository<AddressEntity> addressRepository) 
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressEntity> GetByCodeAndNumber(string postalCode, int Number)
        {
            return await _addressRepository.
        }

        Task<bool> IAddressService.Delete(Guid id)
        {
            throw new NotImplementedException();
        }

         async Task<AddressEntity> IAddressService.Get(Guid id)
        {
            return await _addressRepository.SelectAsync(id);
        }

        async Task<IEnumerable<AddressEntity>> IAddressService.GetAll()
        {
            return  await _addressRepository.SelectAsync();
        }



        Task<AddressEntity> IAddressService.Post(AddressRequest address)
        {
            throw new NotImplementedException();
        }

        Task<AddressEntity> IAddressService.Put(AddressRequest address)
        {
            throw new NotImplementedException();
        }
    }
}
