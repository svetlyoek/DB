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

        DbSet<Student> Students { get; set; }

        DbSet<Course> Courses { get; set; }

        DbSet<Homework> HomeworkSubmissions { get; set; }

        DbSet<StudentCourse> StudentCourses { get; set; }

        DbSet<Resource> Resources { get; set; }


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

            modelBuilder.Entity<Course>()
                .HasData(new Course()
                {
                    CourseId = 1,
                    Name = "Algorithms",
                    StartDate = DateTime.UtcNow,
                    EndDate = new DateTime(2010, 03, 10),
                    Price = 200,
                },

                new Course()
                {
                    CourseId = 2,
                    Name = "Algorithms",
                    StartDate = DateTime.UtcNow,
                    EndDate = new DateTime(2020, 03, 14),
                    Price = 200,
                }
                );

            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            modelBuilder.Entity<Student>()
                .HasData(new Student()
                {
                    StudentId = 1,
                    Name = "Pesho",
                    PhoneNumber = "0888565656",
                    RegisteredOn = DateTime.UtcNow,
                    Birthday = new DateTime(1980 - 02 - 12),

                },
                  new Student()
                  {
                      StudentId = 2,
                      Name = "Pesho",
                      PhoneNumber = "0888565656",
                      RegisteredOn = DateTime.UtcNow,
                      Birthday = new DateTime(1970 - 02 - 12),
                  }
                );

            modelBuilder.ApplyConfiguration(new ResourceConfiguration());

            modelBuilder.Entity<Resource>()
                .HasData(new Resource()
                {
                    ResourceId = 1,
                    Name = "Wikipedia",
                    ResourceType = Resource.Type.Other,
                    CourseId = 1,

                },
                new Resource()
                {
                    ResourceId = 2,
                    Name = "Wikipedia",
                    ResourceType = Resource.Type.Other,
                    CourseId = 2,
                }
                );

            modelBuilder.ApplyConfiguration(new HomeworkConfiguration());

            modelBuilder.Entity<Homework>()
                .HasData(new Homework()
                {
                    HomeworkId = 1,
                    ContentType = Homework.Type.Pdf,
                    SubmissionTime = DateTime.UtcNow,
                    CourseId = 1,
                    StudentId = 1,
                },
                new Homework()
                {
                    HomeworkId = 2,
                    ContentType = Homework.Type.Application,
                    SubmissionTime = DateTime.UtcNow,
                    CourseId = 2,
                    StudentId = 2,
                }
                );

            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());

            modelBuilder.Entity<StudentCourse>()
                .HasData(new StudentCourse()
                {
                    StudentId = 2,
                    CourseId = 2,

                });
        }

    }
}
