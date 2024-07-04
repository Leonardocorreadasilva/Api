using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Mapping
{
    public class ItemsMap : IEntityTypeConfiguration<itemsEntity>
    {
        public void Configure(EntityTypeBuilder<itemsEntity> builder)
        {
            builder.ToTable("items");

            builder.HasKey(i => i.Id);

            // Mapeamento da relação com ProductEntity
            builder.HasOne(i => i.Product)
                   .WithMany() // Se ProductEntity tiver uma coleção de itemsEntity, você pode especificar aqui
                   .HasForeignKey(i => i.ProductId)
                   .IsRequired();

            builder.HasOne(builder => builder.User)
                   .WithMany()
                   .HasForeignKey(i => i.UserId)
                   .IsRequired();

            builder.Property(i => i.Quantity)
                   .IsRequired();

            builder.Property(i => i.Purchased)
                   .IsRequired();

            // Se houver outras propriedades ou relações específicas que precisam ser mapeadas, você pode adicionar mais configurações aqui
        }
    }
}
