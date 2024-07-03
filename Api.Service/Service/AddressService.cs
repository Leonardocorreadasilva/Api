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
        private readonly IRepository<AddressEntity> _addressRepository;
        public AddressService(IRepository<AddressEntity> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressEntity> GetByCodeAndNumber(string postalCode, int number)
        {
            var addresses = await _addressRepository.SelectAsync();

            // Retornará null se não encontrar nenhum endereço correspondente
            return addresses.FirstOrDefault(address => address.PostalCode == postalCode && address.Number == number);
        }

        public async Task<IEnumerable<AddressEntity>> GetAll()
        {
            return await _addressRepository.SelectAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _addressRepository.DeleteAsync(id);
        }

        public async Task<AddressEntity> Get(Guid id)
        {
            return await _addressRepository.SelectAsync(id);
        }

        public async Task<AddressEntity> Post(AddressRequest addressRequest)
        {
            var address = new AddressEntity
            {
                Id = Guid.NewGuid(),
                PostalCode = addressRequest.PostalCode,
                Street = addressRequest.Street,
                Number = addressRequest.Number,
                City = addressRequest.City,
                State = addressRequest.State,
                Country = addressRequest.Country
            };

            return await _addressRepository.InsertAsync(address);
        }

        public async Task<AddressEntity> Put(AddressRequest addressRequest)
        {
            var address = await _addressRepository.SelectAsync(addressRequest.Id);
            if (address == null)
            {
                throw new ArgumentException("Endereço não encontrado.");
            }

            address.PostalCode = addressRequest.PostalCode;
            address.Street = addressRequest.Street;
            address.Number = addressRequest.Number;
            address.City = addressRequest.City;
            address.State = addressRequest.State;
            address.Country = addressRequest.Country;

            return await _addressRepository.UpdateAsync(address);
        }
    }
}
