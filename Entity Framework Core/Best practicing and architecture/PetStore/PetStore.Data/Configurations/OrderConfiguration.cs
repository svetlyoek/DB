namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            order
                .HasKey(k => k.Id);

            order
                .Property(p => p.DateOfPurchase)
                .IsRequired(true);

            order
                .Property(p => p.OrderType)
                .IsRequired(true);

            order
                .Property(p => p.Description)
                .HasMaxLength(250)
                .IsRequired(false)
                .IsUnicode(true);

            order
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            order
                .HasMany(o => o.Pets)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            order
              .HasMany(o => o.Foods)
              .WithOne(f => f.Order)
              .HasForeignKey(f => f.OrderId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
