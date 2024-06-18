using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("address");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.City)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(a => a.State)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(a => a.PostalCode)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(a => a.Number)
                   .IsRequired();

            builder.Property(a => a.Country)
                   .IsRequired()
                   .HasMaxLength(60);
        }
    }
}
