namespace HospitalDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using HospitalDatabase.Models;

    public class VisitationConfiguration : IEntityTypeConfiguration<Visitation>
    {
        public void Configure(EntityTypeBuilder<Visitation> builder)
        {
            builder
               .HasKey(k => k.VisitationId);

            builder
                 .Property(p => p.Date)
                .IsRequired(true);

            builder
                 .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode(true);

            builder
                .HasOne(v => v.Patient)
                .WithMany(v => v.Visitations)
                .HasForeignKey(fk => fk.PatientId);

            builder
                 .HasOne(d => d.Doctor)
                .WithMany(v => v.Visitations)
                .HasForeignKey(fk => fk.DoctorId);
        }
    }
}