namespace HospitalDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class PatientMedicamentConfiguration : IEntityTypeConfiguration<PatientMedicament>
    {
        public void Configure(EntityTypeBuilder<PatientMedicament> builder)
        {
            builder
                  .HasKey(k => new { k.PatientId, k.MedicamentId });

            builder
                .HasOne(p => p.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(fk => fk.PatientId);

            builder
                 .HasOne(m => m.Medicament)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(fk => fk.MedicamentId);
        }
    }
}
