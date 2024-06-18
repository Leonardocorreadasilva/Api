using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Service.Address;
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
        private readonly IRepository<AddressEntity> GetAll;
        public AddressService(IRepository<AddressEntity> addressRepository) 
        {
            GetAll = addressRepository;
        }

        public async Task<AddressEntity> GetByCodeAndNumber(string postalCode, int number)
        {
            var addresses = await GetAll.SelectAsync();

            // Retornará null se não encontrar nenhum endereço correspondente
            return addresses.FirstOrDefault(address => address.PostalCode == postalCode && address.Number == number);
        }




        async Task<IEnumerable<AddressEntity>> IAddressService.GetAll()
        {
            return await GetAll.SelectAsync();
        }

        Task<bool> IAddressService.Delete(Guid id)
        {
            throw new NotImplementedException();
        }

         async Task<AddressEntity> IAddressService.Get(Guid id)
        {
            return await GetAll.SelectAsync(id);
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
