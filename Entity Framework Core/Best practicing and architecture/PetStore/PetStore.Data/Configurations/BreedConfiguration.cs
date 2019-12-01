namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> breed)
        {
            breed
                .HasKey(k => k.Id);

            breed
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            breed
                .HasMany(b => b.Pets)
                .WithOne(p => p.Breed)
                .HasForeignKey(p => p.BreedId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
