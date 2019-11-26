using PetStore.Models.Enums;
using System;

namespace PetStore.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public DateTime Birthdate { get; set; }

        public AnimalGender Gender { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int BreedId { get; set; }

        public Breed Breed { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; set; }

       
    }
}
