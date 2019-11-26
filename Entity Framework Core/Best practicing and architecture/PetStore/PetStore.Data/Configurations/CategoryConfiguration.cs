namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category
                .HasKey(k => k.Id);

            category
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            category
                .Property(p => p.Description)
                .HasMaxLength(250)
                .IsUnicode(true)
                .IsRequired(false);

            category
                .HasMany(f => f.Foods)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            category
                .HasMany(p => p.Pets)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            category
                .HasMany(t => t.Toys)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
