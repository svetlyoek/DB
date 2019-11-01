namespace P01_HospitalDatabase
{
    using P01_HospitalDatabase.Data;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        static void Main(string[] args)
        {
            HospitalContext db = new HospitalContext();

            db.Database.Migrate();

        }
    }
}
