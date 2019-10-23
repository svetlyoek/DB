namespace PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string connectionString = "Server=DESKTOP-JH4M4M9\\MSSQLSERVER01;" + "Database=MinionsDB;" + "Integrated Security=true;";

        static void Main(string[] args)
        {
            var names = new List<string>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();

            using (dbConnection)
            {
                string queryText = @"SELECT Name FROM Minions";

                SqlCommand cmd = new SqlCommand(queryText, dbConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    names.Add((string)reader["Name"]);
                }

                while (names.Count != 0)
                {

                    if (names.Count >= 2)
                    {
                        Console.WriteLine(names[0]);
                        Console.WriteLine(names[names.Count - 1]);

                        names.RemoveAt(0);
                        names.RemoveAt(names.Count - 1);
                    }
                    else
                    {
                        Console.WriteLine(names[0]);
                        names.RemoveAt(0);
                    }

                }
            }

        }
    }
}
