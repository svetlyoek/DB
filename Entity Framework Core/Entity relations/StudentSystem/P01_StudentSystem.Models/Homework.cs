namespace P01_StudentSystem.Data.Models
{
    using System;

    public class Homework
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public Type ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

       public Student Student { get; set; }

        public enum Type
        {
            Application = 0,
            Pdf = 1,
            Zip = 2
        };

    }
}
