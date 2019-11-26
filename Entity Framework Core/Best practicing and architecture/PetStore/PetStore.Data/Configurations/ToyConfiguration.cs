namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class ToyConfiguration : IEntityTypeConfiguration<Toy>
    {
        public void Configure(EntityTypeBuilder<Toy> toy)
        {
            toy
                .HasKey(k => k.Id);

            toy
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            toy
               .Property(p => p.Description)
               .HasMaxLength(250)
               .IsRequired(false)
               .IsUnicode(true);

            toy
                .Property(p => p.Price)
                .IsRequired(true);

            toy
                .HasOne(t => t.Brand)
                .WithMany(b => b.Toys)
                .HasForeignKey(t => t.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            toy
                .HasOne(t => t.Category)
                .WithMany(c => c.Toys)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            toy
                .HasMany(t => t.Orders)
                .WithOne(o => o.Toy)
                .HasForeignKey(o => o.ToyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
