namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;
    using System.Linq;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new StudentSystemContext();

            var courses = context.Courses
                .Select(c => c)
                .ToList();

            var homeworks = context.HomeworkSubmissions
                .Select(h => h)
                .ToList();

            var resources = context.Resources
                .Select(r => r)
                .ToList();

            var students = context.Students
                .Select(s => s)
                .ToList();


            Console.WriteLine("Courses:");

            foreach (var c in courses)
            {

                Console.WriteLine($"{c.Name} - {c.Price} - {c.StartDate} - {c.EndDate}");
            }

            Console.WriteLine("Homeworks:");

            foreach (var h in homeworks)
            {

                Console.WriteLine($"{h.ContentType} - {h.SubmissionTime}");
            }

            Console.WriteLine("Resources:");

            foreach (var r in resources)
            {

                Console.WriteLine($"{r.Name} - {r.ResourceType}");
            }

            Console.WriteLine("Students:");

            foreach (var s in students)
            {

                Console.WriteLine($"{s.Name} - {s.PhoneNumber} - {s.RegisteredOn} - {s.Birthday}");
            }

        }


    }
}
