namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Configurations;
    using P01_StudentSystem.Data.Models;
    using System;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public StudentSystemContext()
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Resource> Resources { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            DatabaseSeeder.CourseSeed(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            DatabaseSeeder.StudentSeed(modelBuilder);

            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            DatabaseSeeder.ResourceSeed(modelBuilder);

            modelBuilder.ApplyConfiguration(new HomeworkConfiguration());
            DatabaseSeeder.HomeworkSeed(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
            DatabaseSeeder.StudentCoursesSeed(modelBuilder);

        }

    }
}
