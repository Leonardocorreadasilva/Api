using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Requests;
using Iss.Data.ViewModels.Response.Usuarios;
using Shared.Request;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IReviewService
    {
        Task<ReviewEntity> Get(Guid id);
        Task<IEnumerable<ReviewEntity>> GetAll();
        Task<ReviewEntity> Post(ReviewRequest review);
        Task<ReviewEntity> Put(ReviewRequest review);
        Task<bool> Delete(Guid id);

    }
}