using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ReviewMap : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            builder.ToTable("Review");

            builder.HasKey(a => a.Id);

            // Relacionamentos
            builder.HasOne(a => a.UserReview)
                   .WithMany() // Se houver uma coleção de Reviews no UserEntity, substitua por ela aqui
                   .HasForeignKey(a => a.UserReviewId)
                   .IsRequired();

            builder.HasOne(a => a.ProductReview)
                   .WithMany() // Se houver uma coleção de Reviews no ProductEntity, substitua por ela aqui
                   .HasForeignKey(a => a.ProductReviewId)
                   .IsRequired();

            // Propriedades
            builder.Property(a => a.Rating)
                   .IsRequired();

            builder.Property(a => a.Coments)
                   .HasMaxLength(500); // Ajuste conforme a necessidade

            builder.Property(a => a.Reviews)
                   .HasMaxLength(500); // Ajuste conforme a necessidade
        }
    }
}
