using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class AddressRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;

        public AddressRepository(MyContext context, DbSet<T> dataset)
        {
            _context = context;
            _dataset = dataset;
        }

        Task<bool> IRepository<T>.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<T>.ExistAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository<T>.SelectAsync()
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
