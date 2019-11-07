namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user
                .HasKey(k => k.UserId);

            user
                .Property(p => p.Balance)
                .IsRequired(true);

            user
                .Property(p => p.Email)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            user
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            user
                .Property(p => p.Password)
                .HasMaxLength(20)
                .IsRequired(true)
                .IsUnicode(true);

            user
                .Property(p => p.Username)
                .HasMaxLength(20)
                .IsUnicode(true)
                .IsRequired(true);
        }
    }
}
