using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interfaces.Services.User;
using Shared.Request;

namespace Api.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;
        public UserService(IRepository<UserEntity> repository) {

            _repository = repository;

        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public Task<UserEntity> Post(UserRequest user)
        {
            UserEntity userEntity = new()
            {
                Nome = user.Nome,
                Email = user.Email,
                Password = user.Password
            };
            userEntity.Address.Street = user.Address.Street;
            userEntity.Address.Number = user.Address.Number;
            userEntity.Address.PostalCode = user.Address.PostalCode;
            userEntity.Address.City = user.Address.City;
            userEntity.Address.State = user.Address.State;
            userEntity.Address.Country = user.Address.Country;

            //_repository.InsertAsync(userEntity.Address);
            return _repository.InsertAsync(userEntity);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}