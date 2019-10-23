namespace ChangeTownsNameCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string connectionString = "Server=DESKTOP-JH4M4M9\\MSSQLSERVER01;" + "Database=MinionsDB;" + "Integrated Security=true;";

        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            var countries = new List<string>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();

            using (dbConnection)
            {
                string queryText = @"UPDATE Towns
                                   SET Name = UPPER(Name)
                                   WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                SqlCommand command = new SqlCommand(queryText, dbConnection);

                command.Parameters.AddWithValue("@countryName", countryName);

                int affectedTownsCount = command.ExecuteNonQuery();


                queryText = @"SELECT t.Name 
                            FROM Towns as t
                            JOIN Countries AS c ON c.Id = t.CountryCode
                            WHERE c.Name = @countryName";


                command = new SqlCommand(queryText, dbConnection);

                command.Parameters.AddWithValue("@countryName", countryName);

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string name = (string)reader["Name"];

                    countries.Add(name);
                }

                if (countries.Count == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    Console.WriteLine($"{affectedTownsCount} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ", countries)}]");
                }
            }
        }
    }
}
