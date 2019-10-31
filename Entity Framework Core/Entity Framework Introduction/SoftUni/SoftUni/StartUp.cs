namespace SoftUni
{
    using System.Linq;
    using System;
    using System.Text;
    using SoftUni.Data;
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Models;
    using System.Globalization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            string result = RemoveTown(context);

            Console.WriteLine(result);

        }

        // problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary,
                });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");

            }

            return sb.ToString().TrimEnd();
        }

        //problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary

                }).Where(e => e.DepartmentName == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName);

            //var employees = (from e in context.Employees
            //                 join d in context.Departments
            //                 on e.DepartmentId equals d.DepartmentId
            //                 where d.Name == "Research and Development"
            //                 select new
            //                 {
            //                     e.FirstName,
            //                     e.LastName,
            //                     d.Name,
            //                     e.Salary,
            //                 }
            //                     ).OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var newAddress = new Address();
            newAddress.AddressText = "Vitoshka 15";
            newAddress.TownId = 4;

            var employeeToFind = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employeeToFind.Address = newAddress;

            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                }).Take(10)
                .ToList();

            foreach (var ad in addresses)
            {
                sb.AppendLine($"{ad.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                    .ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeName} - Manager: {employee.ManagerName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate
                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    var endDate = project.EndDate == null ?
                        "not finished" :
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return sb.ToString().TrimEnd();

        }

        //problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses.Select(a => new
            {
                EmployeesCount = a.Employees.Count,
                TownName = a.Town.Name,
                AddressText = a.AddressText
            })
            .OrderByDescending(a => a.EmployeesCount)
            .ThenBy(a => a.TownName)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 09
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context.Employees
                .FirstOrDefault(e => e.EmployeeId == 147);

            var projects = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                .Select(p => new
                {
                    ProjectName = p.Project.Name
                }).OrderBy(p => p.ProjectName)
                .ToList()
                }).ToList();

            foreach (var e in projects)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"{p.ProjectName}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //problem10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    EmployeesCount = d.Employees.Count,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                .Select(e => new
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    JobTitle = e.JobTitle
                }).OrderBy(e => e.EmployeeFirstName)
                .ThenBy(e => e.EmployeeLastName)
                .ToList()
                }).OrderBy(d => d.EmployeesCount)
            .ThenBy(d => d.DepartmentName)
            .ToList();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} – {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .Select(p => new
                {
                    ProjectName = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                }).OrderByDescending(p => p.StartDate)
            .Take(10)
            .ToList();

            foreach (var p in projects.OrderBy(n => n.ProjectName))
            {
                sb.AppendLine($"{p.ProjectName}")
                    .AppendLine($"{p.Description}")
                    .AppendLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    NewSalary = e.Salary + (e.Salary * 0.12m)
                }).OrderBy(e => e.FirstName).
              ThenBy(e => e.LastName)
              .ToList();

            context.SaveChanges();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.NewSalary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                }).OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projectInEmpProj = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2).ToList();

            var projectToDelete = context
               .Projects
               .FirstOrDefault(p => p.ProjectId == 2);

            foreach (var ep in projectInEmpProj)
            {
                context.EmployeesProjects.Remove(ep);
            }

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context
                .Projects
                .Select(p => new
                {
                    Name = p.Name

                }).Take(10)
            .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 15
        public static string RemoveTown(SoftUniContext context)
        {

            var townToRemove = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            var addresses = context.Addresses.Where(a => a.TownId == townToRemove.TownId).ToList();

            var employees = context.Employees.Where(e => e.Address.Town.Name == "Seattle").ToList();

            foreach (var e in employees)
            {
                e.AddressId = null;
                context.SaveChanges();
            }

            foreach (var a in addresses)
            {
                context.Addresses.Remove(a);
                context.SaveChanges();
            }

            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{addresses.Count} addresses in {townToRemove.Name} were deleted";
        }
    }
}
