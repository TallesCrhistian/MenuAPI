using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MenuAPI.Entites;

namespace MenuAPI.Data.Configurations
{
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("menu_adress");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(a => a.Id)
                .HasColumnName("id")
                .IsRequired();

            entityTypeBuilder.Property(a => a.Street)
                .HasColumnName("street")
                .IsRequired();

            entityTypeBuilder.Property(a => a.State)
               .HasColumnName("state")
               .IsRequired();

            entityTypeBuilder.Property(a => a.City)
               .HasColumnName("city")
               .IsRequired();

            entityTypeBuilder.Property(a => a.Country)
               .HasColumnName("country")
               .IsRequired();

            entityTypeBuilder.Property(a => a.UpdatedAt)
               .HasColumnName("updated_at")
               .IsRequired();

            entityTypeBuilder.Property(a => a.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired();
        }

    }
}
