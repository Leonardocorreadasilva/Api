using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Service.Address;
using Api.Domain.Interfaces.Services.User;
using Iss.Data.ViewModels.Response.Usuarios;
using Shared.Request;
using Shared.Response;

namespace Api.Services.Services
{
    public class UserService(IRepository<UserEntity> userRepository, IRepository<AddressEntity> addressRepository, IAddressService addressService) : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository = userRepository;
        private readonly IRepository<AddressEntity> _addressRepository = addressRepository;


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

        public async Task<UserResponse> Post(UserRequest user)
        {
            try
            {
                // Verificar se o endereço já existe
                AddressEntity existingAddress = await addressService.GetByCodeAndNumber(user.Address.PostalCode, user.Address.Number);

                AddressEntity address;

                if (existingAddress != null)
                {
                    address = existingAddress; // Reutilizar endereço existente
                }
                else
                {
                    address = new AddressEntity()
                    {
                        Street = user.Address.Street,
                        Number = user.Address.Number,
                        PostalCode = user.Address.PostalCode,
                        City = user.Address.City,
                        State = user.Address.State,
                        Country = user.Address.Country
                    };

                    // Inserir o novo endereço no banco de dados
                    var insertedAddress = await _addressRepository.InsertAsync(address);

                    // Verificar se o endereço foi inserido corretamente
                    if (insertedAddress == null || insertedAddress.Id == Guid.Empty)
                    {
                        throw new Exception("Falha ao inserir o endereço no banco de dados.");
                    }

                    address = insertedAddress;
                }

                // Agora podemos usar o ID do endereço inserido ou existente
                UserEntity userEntity = new UserEntity()
                {
                    Nome = user.Nome,
                    Email = user.Email,
                    Password = user.Password,
                    IdAddress = address.Id // Usar o ID do endereço existente ou inserido
                };

                var register = await _userRepository.InsertAsync(userEntity);

                UserResponse ret = new UserResponse()
                {
                    IdUser = register.Id,
                    DataCadastro = register.CreateAt,
                    Email = register.Email,
                    Nome = register.Nome,
                    Address = new AddressResponse()
                    {
                        ID = address.Id,
                        Street = address.Street,
                        Number = address.Number,
                        PostalCode = address.PostalCode,
                        City = address.City,
                        State = address.State,
                        Country = address.Country
                    }
                };

                // Inserir o usuário no banco de dados
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir o usuário no banco de dados", ex);
            }
        }



        public async Task<UserResponse> Put(UserRequest user)
        {
            try
            {
                // Verificar se o endereço já existe
                AddressEntity existingAddress = await addressService.GetByCodeAndNumber(user.Address.PostalCode, user.Address.Number);

                AddressEntity address;

                if (existingAddress != null)
                {
                    address = existingAddress; // Reutilizar endereço existente
                }
                else
                {
                    address = new AddressEntity()
                    {
                        Street = user.Address.Street,
                        Number = user.Address.Number,
                        PostalCode = user.Address.PostalCode,
                        City = user.Address.City,
                        State = user.Address.State,
                        Country = user.Address.Country
                    };

                    // Inserir o novo endereço no banco de dados
                    var insertedAddress = await _addressRepository.InsertAsync(address);

                    // Verificar se o endereço foi inserido corretamente
                    if (insertedAddress == null || insertedAddress.Id == Guid.Empty)
                    {
                        throw new Exception("Falha ao inserir o endereço no banco de dados.");
                    }

                    address = insertedAddress;
                }

                // Preparar o usuário para atualização
                UserEntity userEntityToUpdate = await _userRepository.SelectAsync(user.Id);
                if (userEntityToUpdate == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                userEntityToUpdate.Nome = user.Nome;
                userEntityToUpdate.Email = user.Email;
                userEntityToUpdate.Password = user.Password;
                userEntityToUpdate.IdAddress = address.Id; // Atualizar com o ID do endereço existente ou inserido

                // Atualizar o usuário no banco de dados
                var updatedUser = await _userRepository.UpdateAsync(userEntityToUpdate);

                // Criar e retornar o UserResponse
                return new UserResponse()
                {
                    IdUser = updatedUser.Id,
                    DataCadastro = updatedUser.CreateAt,
                    Email = updatedUser.Email,
                    Nome = updatedUser.Nome,
                    Address = new AddressResponse()
                    {
                        ID = address.Id,
                        Street = address.Street,
                        Number = address.Number,
                        PostalCode = address.PostalCode,
                        City = address.City,
                        State = address.State,
                        Country = address.Country
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o usuário no banco de dados", ex);
            }
        }

        public async Task<UserEntity> Auth(AuthRequest auth)
        {
            // Método de autenticação pode usar o método privado FindUserByNameAndPasswordAsync
            return await FindUserByNameAndPasswordAsync(auth);
        }

        private async Task<UserEntity> FindUserByNameAndPasswordAsync(AuthRequest auth)
        {

            var user = await _userRepository.SelectAsync();


            return user.FirstOrDefault(user => user.Email == auth.email && user.Password == auth.password);
        }
    }
}