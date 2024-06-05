using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specify table names
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<AddressEntity>().ToTable("Addresses");

            // Apply entity mappings
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
        }

    }
}
