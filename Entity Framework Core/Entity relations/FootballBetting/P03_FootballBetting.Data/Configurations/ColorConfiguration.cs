namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> color)
        {
            color
                .HasKey(k => k.ColorId);

            color
                .Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired(true)
                .IsUnicode(false);
        }
    }
}
