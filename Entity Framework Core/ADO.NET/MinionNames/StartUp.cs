namespace MinionNames
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
            int id = int.Parse(Console.ReadLine());
            var minions = new Dictionary<string, int>();
            int counter = 1;

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();

            using (dbConnection)
            {

                string queryText = "SELECT Name FROM Villains WHERE Id = @Id";
                var command = new SqlCommand(queryText, dbConnection);
                command.Parameters.AddWithValue("@Id", id);

                var result = command.ExecuteScalar();

                if (string.IsNullOrWhiteSpace((string)result))
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                    return;
                }

                Console.WriteLine($"Villain: {(string)result}");


                queryText = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                command = new SqlCommand(queryText, dbConnection);
                command.Parameters.AddWithValue("@Id", id);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        int minionAge = (int)reader["Age"];

                        if (!minions.ContainsKey(name))
                        {
                            minions[name] = 0;
                        }

                        minions[name] = minionAge;
                    }

                    foreach (var minion in minions.OrderBy(m => m.Key))
                    {
                        string name = minion.Key;
                        int age = minion.Value;
                        Console.WriteLine($"{counter}. {name} - {age}");
                        counter++;
                    }
                }
                else
                {
                    Console.WriteLine("(no minions)");
                }
            }
        }
    }
}

