namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    using System;

    public static class DatabaseSeeder
    {
        public static void StudentCoursesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasData(new StudentCourse()
                {
                    StudentId = 2,
                    CourseId = 2,

                });
        }

        public static void StudentSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                 .HasData(new Student()
                 {
                     StudentId = 1,
                     Name = "Pesho",
                     PhoneNumber = "0888565656",
                     RegisteredOn = DateTime.UtcNow,
                     Birthday = new DateTime(1980 - 04 - 08),

                 },
                   new Student()
                   {
                       StudentId = 2,
                       Name = "Dimitar",
                       PhoneNumber = "0888565656",
                       RegisteredOn = DateTime.UtcNow,
                       Birthday = new DateTime(1970 - 02 - 12),
                   }
                 );
        }

        public static void ResourceSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasData(new Resource()
                {
                    ResourceId = 1,
                    Name = "Youtube",
                    ResourceType = Resource.Type.Video,
                    CourseId = 1,

                },
                new Resource()
                {
                    ResourceId = 2,
                    Name = "Wikipedia",
                    ResourceType = Resource.Type.Document,
                    CourseId = 2,
                }
                );
        }

        public static void HomeworkSeed(ModelBuilder modelBuilder)
        {
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
        }

        public static void CourseSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
               .HasData(new Course()
               {
                   CourseId = 1,
                   Name = "Algorithms",
                   StartDate = DateTime.UtcNow,
                   EndDate = new DateTime(2010, 03, 10),
                   Price = 250.40m,
               },

               new Course()
               {
                   CourseId = 2,
                   Name = "Algorithms",
                   StartDate = new DateTime(2009, 03, 10),
                   EndDate = new DateTime(2020, 03, 14),
                   Price = 200,
               }
               );
        }
    }
}