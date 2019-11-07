namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> game)
        {
            game
                .HasKey(k => k.GameId);

            game
                .Property(p => p.AwayTeamBetRate)
                .IsRequired(true);

            game
                .Property(p => p.AwayTeamGoals)
                .IsRequired(true);

            game
                .Property(p => p.DrawBetRate)
                .IsRequired(true);

            game
                .Property(p => p.HomeTeamBetRate)
                .IsRequired(true);

            game
                .Property(p => p.HomeTeamGoals)
                .IsRequired(true);

            game
                .Property(p => p.Result)
                .HasMaxLength(20)
                .IsRequired(true)
                .IsUnicode(true);

            game
                .Property(p => p.DateTime)
                .IsRequired(true);

            game
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            game
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
