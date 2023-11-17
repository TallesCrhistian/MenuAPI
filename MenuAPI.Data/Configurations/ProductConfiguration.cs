using MenuAPI.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MenuAPI.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("menu_product");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(a => a.Id)
                .HasColumnName("id")
                .IsRequired();

            entityTypeBuilder.Property(a => a.Name)
                .HasColumnName("name")
                .IsRequired();

            entityTypeBuilder.Property(a => a.UrlImage)
                .HasColumnName("url_image")
                .IsRequired();

            entityTypeBuilder.Property(a => a.Description)
                .HasColumnName("description")
                .IsRequired();

            entityTypeBuilder.Property(a => a.EnterpriseId)
                .HasColumnName("enterprise_id")
                .IsRequired();

            entityTypeBuilder.Property(a => a.Group)
                .HasColumnName("group")
                .HasColumnType("group_enum")
                .IsRequired();

            entityTypeBuilder.Property(a => a.Value)
                .HasColumnName("value")
                .IsRequired();

            entityTypeBuilder.Property(a => a.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            entityTypeBuilder.Property(a => a.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();

            entityTypeBuilder.HasOne(e => e.Enterprise)
                .WithMany(a => a.Products)
                .HasForeignKey(e => e.EnterpriseId);
        }
    }
}
