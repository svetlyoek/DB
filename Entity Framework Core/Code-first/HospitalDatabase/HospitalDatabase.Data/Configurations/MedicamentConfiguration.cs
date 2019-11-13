namespace HospitalDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using HospitalDatabase.Models;

    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder
                .HasKey(k => k.MedicamentId);

            builder
                 .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            builder
                .HasMany(p => p.Prescriptions)
                .WithOne(m => m.Medicament)
                .HasForeignKey(fk => fk.MedicamentId);
        }
    }
}