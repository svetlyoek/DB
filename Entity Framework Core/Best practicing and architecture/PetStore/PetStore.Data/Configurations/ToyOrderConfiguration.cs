namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class ToyOrderConfiguration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> toyOrder)
        {
            toyOrder
                 .HasKey(pk => new { pk.OrderId, pk.ToyId });

            toyOrder
                .HasOne(to => to.Toy)
                .WithMany(t => t.Orders)
                .HasForeignKey(to => to.ToyId)
                .OnDelete(DeleteBehavior.Cascade);

            toyOrder
                .HasOne(to => to.Order)
                .WithMany(o => o.Toys)
                .HasForeignKey(to => to.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
