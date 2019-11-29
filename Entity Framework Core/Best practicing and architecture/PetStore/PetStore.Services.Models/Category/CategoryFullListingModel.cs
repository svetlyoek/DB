namespace PetStore.Services.Models.Category
{
    using PetStore.Services.Models.Food;
    using PetStore.Services.Models.Pet;
    using PetStore.Services.Models.Toy;
    using System.Collections.Generic;

    public class CategoryFullListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<FoodListingModel> Foods { get; set; }

        public ICollection<ToyListingModel> Toys { get; set; }

        public ICollection<PetFullListingModel> Pets { get; set; }
    }
}
