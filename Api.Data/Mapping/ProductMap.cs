using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(500);

            builder.Property(p => p.Stock)
                   .IsRequired();

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // Corrigindo a configuração para a relação com UserEntity
            builder.HasOne(p => p.User) // Ajuste na propriedade para seguir a convenção de nomenclatura
                   .WithMany() // Aqui você pode especificar a propriedade de navegação inversa se houver
                   .HasForeignKey(p => p.UserId) // Usando UserId como FK
                   .IsRequired();

            // Corrigindo a configuração para a relação com AddressEntity
            builder.HasOne(p => p.Address)
                   .WithMany() // Aqui você pode especificar a propriedade de navegação inversa se houver
                   .HasForeignKey(p => p.AddressId) // Usando AddressId como FK
                   .IsRequired();


            builder.HasOne(p => p.ProductCategory)
                   .WithMany()
                   .HasForeignKey(p => p.ProductCategoryId)
                   .IsRequired();
        }
    }
}
