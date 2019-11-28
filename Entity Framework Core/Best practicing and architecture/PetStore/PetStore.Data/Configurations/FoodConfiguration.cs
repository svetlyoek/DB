namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> food)
        {
            food
                .HasKey(k => k.Id);

            food
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            food
                .Property(p => p.ExpirationDate)
                .IsRequired(true);

            food
                .Property(p => p.Price)
                .IsRequired(true);

            food
                .Property(p => p.Weight)
                .IsRequired(true);

            food
                .HasOne(f => f.Brand)
                .WithMany(b => b.Foods)
                .HasForeignKey(f => f.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            food
               .HasOne(f => f.Category)
               .WithMany(b => b.Foods)
               .HasForeignKey(f => f.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

            food
              .HasMany(f => f.Orders)
              .WithOne(o => o.Food)
              .HasForeignKey(o => o.FoodId)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
