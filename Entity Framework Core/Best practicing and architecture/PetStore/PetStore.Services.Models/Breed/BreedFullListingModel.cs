namespace PetStore.Services.Models.Breed
{
    using PetStore.Services.Models.Pet;
    using System.Collections.Generic;

    public class BreedFullListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PetFullListingModel> Pets { get; set; }
    }
}
