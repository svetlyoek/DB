namespace IncreaseAgeStoredProcedure
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string connectionString = "Server=DESKTOP-JH4M4M9\\MSSQLSERVER01;" + "Database=MinionsDB;" + "Integrated Security=true;";

        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();

            using (dbConnection)
            {
                string queryText = @"Exec dbo.usp_GetOlder @Id";

                SqlCommand cmd = new SqlCommand(queryText, dbConnection);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();

                queryText = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

                cmd = new SqlCommand(queryText, dbConnection);

                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];

                    Console.WriteLine($"{name} - {age}");
                }
            }
        }
    }
}
