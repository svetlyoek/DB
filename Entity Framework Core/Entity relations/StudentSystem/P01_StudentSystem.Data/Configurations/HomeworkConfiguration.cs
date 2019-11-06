namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> homework)
        {
            homework
                .HasKey(k => k.HomeworkId);

            homework
                .Property(p => p.Content)
                .IsUnicode(false)
                .IsRequired(false);

            homework
                .Property(p => p.ContentType)
                .IsRequired(true);

            homework
                .Property(p => p.SubmissionTime)
                .IsRequired(true);

            homework
                .HasOne(s => s.Student)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(s => s.StudentId);

            homework
                .HasOne(c => c.Course)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
