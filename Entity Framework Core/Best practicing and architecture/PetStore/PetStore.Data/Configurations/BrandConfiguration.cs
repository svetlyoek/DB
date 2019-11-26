namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> brand)
        {
            brand
                .HasKey(k => k.Id);

            brand
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            brand
                .HasMany(b => b.Foods)
                .WithOne(f => f.Brand)
                .HasForeignKey(f => f.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            brand
                .HasMany(b => b.Toys)
                .WithOne(t => t.Brand)
                .HasForeignKey(t => t.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
