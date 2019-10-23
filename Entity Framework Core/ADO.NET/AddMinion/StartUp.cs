namespace AddMinion
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static int TownId;
        public static int MinionId;
        public static int VillainId;

        private const string connectionString = "Server=DESKTOP-JH4M4M9\\MSSQLSERVER01;" + "Database=MinionsDB;" + "Integrated Security=true;";

        static void Main(string[] args)
        {
            List<string> minionInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> villainInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string minionName = minionInput[1];
            int minionAge = int.Parse(minionInput[2]);
            string townName = minionInput[3];

            string villainName = villainInput[1];

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();

            using (dbConnection)
            {

                string queryText = @"SELECT Id FROM Towns WHERE Name = @townName";

                SqlCommand cmd = new SqlCommand(queryText, dbConnection);

                cmd.Parameters.AddWithValue("@townName", townName);

                object town = cmd.ExecuteScalar();

                if (town != null)
                {
                    TownId = (int)town;
                }

                else
                {
                    queryText = @"INSERT INTO Towns (Name) VALUES (@townName)";

                    cmd = new SqlCommand(queryText, dbConnection);

                    cmd.Parameters.AddWithValue("@townName", townName);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine($"Town {townName} was added to the database.");
                }


                queryText = @"SELECT Id FROM Minions WHERE Name = @Name";

                cmd = new SqlCommand(queryText, dbConnection);

                cmd.Parameters.AddWithValue("@Name", minionName);

                object minion = cmd.ExecuteScalar();

                if (minion != null)
                {
                    MinionId = (int)minion;
                }
                else
                {
                    queryText = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

                    cmd = new SqlCommand(queryText, dbConnection);

                    cmd.Parameters.AddWithValue("@nam", minionName);
                    cmd.Parameters.AddWithValue("@age", minionAge);
                    cmd.Parameters.AddWithValue("@townId", townName);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Minion {minionName} was added to the database.");

                }


                queryText = @"SELECT Id FROM Villains WHERE Name = @Name";

                cmd = new SqlCommand(queryText, dbConnection);

                cmd.Parameters.AddWithValue("@Name", villainName);

                object villain = cmd.ExecuteScalar();

                if (villain != null)
                {
                    VillainId = (int)villain;
                }
                else
                {
                    queryText = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

                    cmd = new SqlCommand(queryText, dbConnection);

                    cmd.Parameters.AddWithValue("@villainName", villainName);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine($"Villain {villainName} was added to the database.");

                }


                queryText = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

                cmd = new SqlCommand(queryText, dbConnection);

                cmd.Parameters.AddWithValue("@villainId", VillainId);
                cmd.Parameters.AddWithValue("@minionId", MinionId);

                cmd.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

            }
        }
    }
}

