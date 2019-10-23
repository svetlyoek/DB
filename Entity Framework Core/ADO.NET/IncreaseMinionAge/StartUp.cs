namespace IncreaseMinionAge
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        private const string connectionString = "Server=DESKTOP-JH4M4M9\\MSSQLSERVER01;" + "Database=MinionsDB;" + "Integrated Security=true;";

        static void Main(string[] args)
        {
            List<int> ids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var minions = new Dictionary<string, int>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();

            using (dbConnection)
            {
                string queryText = @"UPDATE Minions
                               SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                               WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(queryText, dbConnection);

                foreach (var id in ids)
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }

                queryText = @"SELECT Name, Age FROM Minions";

                cmd = new SqlCommand(queryText, dbConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];

                    if (!minions.ContainsKey(name))
                    {
                        minions[name] = 0;
                    }

                    minions[name] = age;
                }


                foreach (var minion in minions)
                {
                    Console.WriteLine($"{minion.Key} {minion.Value}");
                }

            }
        }
    }
}
