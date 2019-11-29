namespace PetStore
{
    using PetStore.Data;
    using PetStore.Services.Implementations;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new PetStoreDbContext();

            var brandService = new BrandService(db);

            var categoryService = new CategoryService(db);

            var toyService = new ToyService(db);

            var foodService = new FoodService(db);

            var orderService = new OrderService(db);

            var userService = new UserService(db);

            var breedService = new BreedService(db);

            var petService = new PetService(db);

            //for(int i=0;i<20;i++)
            //{
            //    string name = "Spas" +" "+ i;
            //    DateTime dateTime = new DateTime(2020 + i / 08 + i / 03 + i);
            //    decimal price = 20 + i;
            //    petService.Add(name, dateTime, "Male", price, 2, 1, 7);
            //}
            
        }
    }
}
