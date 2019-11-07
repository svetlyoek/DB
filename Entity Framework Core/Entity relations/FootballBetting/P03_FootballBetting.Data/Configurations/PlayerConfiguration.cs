namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> player)
        {
            player
                 .HasKey(k => k.PlayerId);

            player
                .Property(p => p.IsInjured)
                .IsRequired(true);

            player
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);

            player
                .Property(p => p.SquadNumber)
                .IsRequired(true);

            player
                .HasOne(pl => pl.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(pl => pl.PositionId);

            player
                .HasOne(pl => pl.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(pl => pl.TeamId);
        }
    }
}
