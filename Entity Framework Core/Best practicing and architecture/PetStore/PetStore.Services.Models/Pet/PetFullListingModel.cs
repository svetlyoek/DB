namespace PetStore.Services.Models.Pet
{
    using PetStore.Models.Enums;
    using System;

    public class PetFullListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public DateTime Birthdate { get; set; }


        public AnimalGender Gender { get; set; }


        public string Description { get; set; }


        public decimal Price { get; set; }


        public int BreedId { get; set; }

        public string Breed { get; set; }


        public int CategoryId { get; set; }

        public string Category { get; set; }


        public int? OrderId { get; set; }

        public string Order { get; set; }
    }
}
