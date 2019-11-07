namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> bet)
        {
            bet
                .HasKey(k => k.BetId);

            bet
                .Property(p => p.Amount)
                .IsRequired(true);

            bet
                .Property(p => p.Prediction)
                .HasMaxLength(200)
                .IsRequired(true)
                .IsUnicode();

            bet
                .Property(p => p.DateTime)
                .IsRequired(true);

            bet
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);

            bet
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

        }
    }
}
