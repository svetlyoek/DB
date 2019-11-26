namespace PetStore
{
    using PetStore.Data;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new PetStoreDbContext()
            {

            };
        }
    }
}
