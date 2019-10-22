namespace VillainNames
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string connectionString = "Server=DESKTOP-JH4M4M9\\MSSQLSERVER01;" + "Database=MinionsDB;" + "Integrated Security=true;";

        static void Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();

            using (dbConnection)
            {
                string queryText = @" SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                   FROM Villains AS v 
                                   JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                   GROUP BY v.Id, v.Name 
                                   HAVING COUNT(mv.VillainId) > 3 
                                   ORDER BY COUNT(mv.VillainId)";


                SqlCommand printCommand = new SqlCommand(queryText, dbConnection);

                SqlDataReader reader = printCommand.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                }
            }
        }
    }
}
