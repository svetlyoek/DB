using System;
using System.Data.SqlClient;

public class Program
{
    static void Main(string[] args)
    {
        SqlConnection dbCon = new SqlConnection
            (
            "Server=.\\MSSQLSERVER01;" +
            "Database=SoftUni;" +
            "Integrated Security=true;"
            );

        dbCon.Open();

        using (dbCon)
        {
            SqlCommand command = new SqlCommand("select count(*) from Employees", dbCon);
            int employeeCount = (int)command.ExecuteScalar();
            Console.WriteLine(employeeCount);
        }

    }
}