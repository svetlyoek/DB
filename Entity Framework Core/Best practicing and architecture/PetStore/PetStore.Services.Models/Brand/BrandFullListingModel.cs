namespace PetStore.Services.Models.Brand
{
    using PetStore.Models;
    using PetStore.Services.Models.Food;
    using PetStore.Services.Models.Toy;
    using System.Collections.Generic;

    public class BrandFullListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ToyListingModel> Toys { get; set; }

        public ICollection<FoodListingModel> Foods { get; set; }

    }
}
