using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Street);
            builder.Property(t => t.Street).IsRequired().HasMaxLength(100);
            builder.Property(t => t.City).IsRequired().HasMaxLength(60);
            builder.Property(t => t.State).IsRequired().HasMaxLength(60);
            builder.Property(t => t.Country).IsRequired().HasMaxLength(60);
            builder.Property(t => t.PostalCode).IsRequired().HasMaxLength(60);
            //builder.Property(t => t.Address).IsRequired();

        }
    }
}
