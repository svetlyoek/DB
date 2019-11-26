namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> pet)
        {
            pet
                .HasKey(k => k.Id);

            pet
                .Property(p => p.Birthdate)
                .IsRequired(true);

            pet
                .Property(p => p.Gender)
                .IsRequired(true);

            pet
                .Property(p => p.Description)
                .HasMaxLength(250)
                .IsRequired(false)
                .IsUnicode(true);

            pet
                .Property(p => p.Price)
                .IsRequired(true);

            pet
                .HasOne(p => p.Breed)
                .WithMany(b => b.Pets)
                .HasForeignKey(p => p.BreedId)
                .OnDelete(DeleteBehavior.Cascade);

            pet
                .HasOne(p => p.Category)
                .WithMany(c => c.Pets)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            pet
                .HasOne(p => p.Order)
                .WithMany(o => o.Pets)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
