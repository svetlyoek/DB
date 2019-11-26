namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
    {
        public void Configure(EntityTypeBuilder<FoodOrder> foodOrder)
        {
            foodOrder
                .HasKey(pk => new { pk.FoodId, pk.OrderId });

            foodOrder
                .HasOne(fo => fo.Food)
                .WithMany(o => o.Orders)
                .HasForeignKey(fo => fo.FoodId)
                .OnDelete(DeleteBehavior.Restrict);

            foodOrder
                .HasOne(fo => fo.Order)
                .WithMany(o => o.Foods)
                .HasForeignKey(fo => fo.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
