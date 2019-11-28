namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Models.Enums;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Pet;
    using System;
    using System.Linq;

    public class PetService : IPetService
    {
        private readonly PetStoreDbContext data;

        public PetService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string name, DateTime birthdate, string gender, decimal price, int breedId, int categoryId, int orderId)
        {
            if (name.Length > DataValidation.PetNameLength)
            {
                throw new ArgumentException(ExceptionMessages.PetExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.PetExceptions.NameNullOrEmptyException);
            }

            else if (this.data.Pets.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.PetExceptions.ExistingPetException);
            }

            AnimalGender myGender;

            Enum.TryParse("gender", out myGender);

            var pet = new Pet
            {
                Name = name,
                Birthdate = birthdate,
                Gender = myGender,
                Price = price,
                BreedId = breedId,
                CategoryId = categoryId,
                OrderId = orderId
            };

            this.data.Pets.Add(pet);

            this.data.SaveChanges();

            Console.WriteLine($"{pet.Name} successfully added in the database.");
        }

        public void Remove(string name)
        {
            if (name.Length > DataValidation.PetNameLength)
            {
                throw new ArgumentException(ExceptionMessages.PetExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.PetExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Pets.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.PetExceptions.NotExistingPetException);
            }

            var pet = this.data
                .Pets
                .FirstOrDefault(b => b.Name == name);

            this.data.Pets.Remove(pet);

            this.data.SaveChanges();

            Console.WriteLine($"{pet.Name} successfully removed from the database.");

        }

        public void GetObject(string name)
        {
            if (name.Length > DataValidation.PetNameLength)
            {
                throw new ArgumentException(ExceptionMessages.PetExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.PetExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Pets.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.PetExceptions.NotExistingPetException);
            }

            var pet = this.data.Pets
                 .Where(p => p.Name == name)
                 .Select(p => new PetListingModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Birthdate = p.Birthdate,
                     BreedName = p.Breed.Name,
                     CategoryName = p.Category.Name,
                     Description = p.Description,
                     Gender = p.Gender.ToString(),
                     OrderId = p.OrderId,
                     Price = p.Price
                 })
                 .FirstOrDefault();

            Console.WriteLine($"Pet id: {pet.Id}, pet name: {pet.Name}, pet birthdate: {pet.Birthdate}, " +
                $"pet breed name: {pet.BreedName}, pet category name: {pet.CategoryName}, pet gender: {pet.Gender}, " +
                $"pet order id: {pet.OrderId}, pet price: {pet.Price}");

        }

    }
}
