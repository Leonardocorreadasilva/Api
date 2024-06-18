using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Service.Address;
using Api.Domain.Interfaces.Services.User;
using Shared.Request;

namespace Api.Services.Services
{
    public class UserService : IUserService
    {
            private readonly IRepository<UserEntity> _userRepository;
            private readonly IRepository<AddressEntity> _addressRepository;

        public UserService(IRepository<UserEntity> userRepository, IRepository<AddressEntity> addressRepository, IAddressService addressService) {

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

        public async Task<UserEntity> Post(UserRequest user)
{
    try
    {
        AddressEntity address = new AddressEntity()
        {
            Street = user.Address.Street,
            Number = user.Address.Number,
            PostalCode = user.Address.PostalCode,
            City = user.Address.City,
            State = user.Address.State,
            Country = user.Address.Country
        };

        // Inserir o endereço no banco de dados
        var insertedAddress = await _addressRepository.InsertAsync(address);
        
        // Verificar se o endereço foi inserido corretamente
        if (insertedAddress == null || insertedAddress.Id == Guid.Empty)
        {
            throw new Exception("Falha ao inserir o endereço no banco de dados.");
        }

        // Agora podemos usar o ID do endereço inserido
        UserEntity userEntity = new UserEntity()
        {
            Nome = user.Nome,
            Email = user.Email,
            Password = user.Password,
            AddressId = insertedAddress.Id // Usar o ID do endereço inserido
        };

        // Inserir o usuário no banco de dados
        return await _userRepository.InsertAsync(userEntity);
    }
    catch (Exception ex)
    {
        throw new Exception("Erro ao inserir o usuário no banco de dados", ex);
    }
}




        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _userRepository.UpdateAsync(user);
        }
    }
}