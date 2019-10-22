namespace SqlDataReaderDemo
{

    using System;
    using System.Data.SqlClient;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.\\MSSQLSERVER01;" + "Database=SoftUni;" + "Integrated Security=true;");

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("select * from Employees", connection);
                SqlDataReader reader = command.ExecuteReader();


                using (reader)
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        decimal salary = (decimal)reader["Salary"];
                        Console.WriteLine($"{firstName} {lastName} - {salary:f2}");
                    }
                }

            }
        }
    }
}
