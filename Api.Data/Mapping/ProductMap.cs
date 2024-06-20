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

            builder.HasOne(u => u.user)
                .WithMany()
                .HasForeignKey(u => u.Id)
                .IsRequired();

            builder.HasOne(u => u.Address)
                .WithMany()
                .HasForeignKey(u => u.Id)
                .IsRequired();
        }
    }
}
