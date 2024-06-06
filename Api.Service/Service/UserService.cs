using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interfaces.Services.User;
using Shared.Request;

namespace Api.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<AddressEntity> _addressRepository;
        public UserService(IRepository<UserEntity> userRepository, IRepository<AddressEntity> addressRepository) {

            _userRepository = userRepository;
            _addressRepository = addressRepository;

        }
        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _userRepository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _userRepository.SelectAsync();
        }

        public Task<UserEntity> Post(UserRequest user)
        {
            AddressEntity address = new AddressEntity();
            address.Street = user.Address.Street;
            address.Number = user.Address.Number;
            address.PostalCode = user.Address.PostalCode;
            address.City = user.Address.City;
            address.State = user.Address.State;
            address.Country = user.Address.Country;
            var addressComit = _addressRepository.InsertAsync(address);
            UserEntity userEntity = new()
            {
                Nome = user.Nome,
                Email = user.Email,
                Password = user.Password,
                AddressId = addressComit.Result.Id,
            };
            
            return _userRepository.InsertAsync(userEntity);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _userRepository.UpdateAsync(user);
        }
    }
}