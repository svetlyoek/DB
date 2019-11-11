namespace HospitalDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                 .HasKey(k => k.PatientId);

            builder
                  .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            builder
                 .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();

            builder
                 .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder
                  .Property(p => p.HasInsurance)
                .IsRequired(true);

            builder
                .HasMany(p => p.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(fk => fk.PatientId);

            builder
                .HasMany(p => p.Diagnoses)
                .WithOne(p => p.Patient)
                .HasForeignKey(fk => fk.PatientId);

            builder
                 .HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(fk => fk.PatientId);
        }
    }
}
