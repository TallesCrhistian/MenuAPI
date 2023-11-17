using MenuAPI.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MenuAPI.Data.Configurations
{
    public class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("menu_enterprise");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(a => a.Id)
               .HasColumnName("id")
               .IsRequired();

            entityTypeBuilder.Property(a => a.AdressId)
                .HasColumnName("adress_id")
                .IsRequired();

            entityTypeBuilder.Property(a => a.CNPJ)
                .HasColumnName("cnpj")
                .IsRequired();

            entityTypeBuilder.Property(a => a.Name)
                .HasColumnName("name")
                .IsRequired();

            entityTypeBuilder.Property(a => a.SocialReason)
                .HasColumnName("social_reason")
                .IsRequired();

            entityTypeBuilder.Property(a => a.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            entityTypeBuilder.Property(a => a.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();

            entityTypeBuilder.HasOne(e => e.Adress)
                .WithOne(a => a.Enterprise)
                .HasForeignKey<Enterprise>(e => e.AdressId);
        }
    }
}
