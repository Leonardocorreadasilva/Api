using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Iss.Data.ViewModels.Response.Usuarios;
using Shared.Request;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<UserEntity> Auth(AuthRequest auth);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserResponse> Post(UserRequest user);
        Task<UserResponse> Put(UserRequest user);
        Task<bool> Delete(Guid id);

    }
}