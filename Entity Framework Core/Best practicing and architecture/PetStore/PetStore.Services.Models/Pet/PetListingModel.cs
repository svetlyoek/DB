namespace PetStore.Services.Models.Pet
{
    using System;

    public class PetListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string BreedName { get; set; }

        public string CategoryName { get; set; }

        public int? OrderId { get; set; }
    }
}
