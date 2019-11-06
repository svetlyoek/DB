namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> studentCourse)
        {
            studentCourse
                .HasKey(pk => new { pk.StudentId, pk.CourseId });

            studentCourse
                .HasOne(s => s.Student)
                .WithMany(sc => sc.CourseEnrollments)
                .HasForeignKey(s => s.StudentId);

            studentCourse
                .HasOne(c => c.Course)
                .WithMany(sc => sc.StudentsEnrolled)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
