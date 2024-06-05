using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Shared.Request;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> Post(UserRequest user);
        Task<UserEntity> Put(UserEntity user);
        Task<bool> Delete(Guid id);

    }
}