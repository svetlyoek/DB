namespace PetStore
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Models.Enums;
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


            //Pet seeder

            //for (int i = 0; i < 7; i++)
            //{
            //    string name = "Dragan" + " " + i;
            //    DateTime dateTime = new DateTime(2020 + i / 08 + i / 03 + i);
            //    decimal price = 20 + i;

            //    var pet = new Pet()
            //    {
            //        Name=name,
            //        Birthdate=dateTime,
            //        Gender=AnimalGender.Female,
            //        Price=price,
            //        BreedId=2,
            //        CategoryId=1,
            //        OrderId=7
            //    };

            //    db.Pets.Add(pet);

            //    db.SaveChanges();
            //}

        }
    }
}
