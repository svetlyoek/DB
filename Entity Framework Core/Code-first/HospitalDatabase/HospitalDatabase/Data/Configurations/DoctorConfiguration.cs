namespace HospitalDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
               .HasKey(k => k.DoctorId);

            builder
                 .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            builder
                .Property(p => p.Specialty)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            builder
                .Property(p => p.Password)
                .HasMaxLength(10)
                .IsUnicode(true)
                .IsRequired(true);
        }
    }
}
