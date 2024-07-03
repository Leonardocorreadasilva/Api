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
    internal class CartMap : IEntityTypeConfiguration<CartEntity>
    {
        public void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(c => c.UserId);

            builder.Property(c => c.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Purchased)
                .IsRequired();

            // Configuração do relacionamento 1 para muitos com itemsEntity
            builder.HasMany(c => c.Items)
                .WithOne() // Este método precisa ser completado com a propriedade de navegação inversa, se houver.
                .HasForeignKey(p => p.ProductId); // Este campo precisa ser adicionado à entidade itemsEntity para completar o mapeamento.

            // Adicione mais configurações conforme necessário
        }
    }
}
