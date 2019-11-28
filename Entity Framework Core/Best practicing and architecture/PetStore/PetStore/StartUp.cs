namespace PetStore
{
    using PetStore.Data;
    using PetStore.Services.Implementations;

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

        }
    }
}
