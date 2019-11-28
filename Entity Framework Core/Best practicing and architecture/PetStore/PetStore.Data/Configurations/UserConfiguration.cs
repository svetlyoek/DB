namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user
                .HasKey(k => k.Id);

            user
                .Property(p => p.FullName)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);

            user
                .Property(p => p.Email)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);

            user
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
