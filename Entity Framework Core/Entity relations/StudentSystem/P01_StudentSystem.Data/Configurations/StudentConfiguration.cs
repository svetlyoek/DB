namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student
                .HasKey(k => k.StudentId);

            student
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            student
                .Property(p => p.PhoneNumber)
                .HasColumnType("CHAR(10)")
                .IsRequired(true);

            student
                .Property(p => p.RegisteredOn)
                .IsRequired(true);

            student
                .Property(p => p.Birthday)
                .IsRequired(true);

        }
    }
}
