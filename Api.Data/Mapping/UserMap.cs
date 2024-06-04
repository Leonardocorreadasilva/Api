using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Email);
            builder.Property(t => t.Email).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(60);
            //builder.Property(t => t.Password).IsRequired().HasMaxLength(60);
            //builder.Property(t => t.Address).IsRequired();
            
        }
    }
}
