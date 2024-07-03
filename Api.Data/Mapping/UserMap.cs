using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(u => u.Email)
                    .IsUnique();

            builder.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(u => u.Address)
         .WithMany() // Aqui você pode especificar a propriedade de navegação inversa se houver
         .HasForeignKey(u => u.IdAddress) // Usando AddressId como FK
         .IsRequired();
        }
    }
}

