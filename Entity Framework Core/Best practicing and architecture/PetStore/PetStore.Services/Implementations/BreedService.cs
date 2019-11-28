namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Breed;
    using PetStore.Services.Models.Pet;
    using System;
    using System.Linq;

    public class BreedService : IBreedService
    {
        private readonly PetStoreDbContext data;

        public BreedService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string name)
        {
            if (name.Length > DataValidation.BrandNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NameNullOrEmptyException);
            }

            else if (this.data.Breeds.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.ExistingBreedException);
            }

            var breed = new Breed
            {
                Name = name
            };

            this.data.Breeds.Add(breed);

            this.data.SaveChanges();

            Console.WriteLine($"{breed.Name} successfully added in the database.");

        }

        public void Remove(string name)
        {
            if (name.Length > DataValidation.BreedNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Breeds.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NotExistingBreedException);
            }

            var breed = this.data
                .Breeds
                .FirstOrDefault(b => b.Name == name);

            this.data.Breeds.Remove(breed);

            this.data.SaveChanges();

            Console.WriteLine($"{breed.Name} successfully removed from the database.");
        }

        public void GetObject(string name)
        {
            if (name.Length > DataValidation.BreedNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Breeds.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NotExistingBreedException);
            }

            var breed = this.data.Breeds
                 .Where(b => b.Name == name)
                 .Select(b => new BreedListingModel
                 {
                     Id = b.Id,
                     Name = b.Name
                 })
                 .FirstOrDefault();

            Console.WriteLine($"Breed id: {breed.Id}, name: {breed.Name}");

        }

        public void GetObjectWithCollections(string name)
        {
            if (name.Length > DataValidation.BreedNameLength)
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NameLengthException);
            }

            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NameNullOrEmptyException);
            }

            else if (!this.data.Breeds.Any(b => b.Name == name))
            {
                throw new ArgumentException(ExceptionMessages.BreedExceptions.NotExistingBreedException);
            }

            var breeds = this.data.Breeds
                 .Where(b => b.Name == name)
                 .Select(b => new BreedFullListingModel
                 {
                     Id = b.Id,
                     Name = b.Name,
                     Pets = b.Pets
                     .Select(p => new PetListingModel
                     {
                         Id = p.Id,
                         Name = p.Name,
                         Birthdate = p.Birthdate,
                         Gender = p.Gender.ToString(),
                         BreedName = p.Breed.Name,
                         CategoryName = p.Category.Name,
                         Description = p.Description,
                         Price = p.Price,
                         OrderId = p.OrderId
                     })
                     .ToList()
                 })
                 .ToList();

            foreach (var breed in breeds)
            {
                Console.WriteLine($"Breed id:{breed.Id}, breed name: {breed.Name}");
                Console.WriteLine("Pets:");

                foreach (var pet in breed.Pets)
                {
                    Console.WriteLine($"Pet id: {pet.Id}, pet name: {pet.Name}, pet birthdate: {pet.Birthdate},pet gender: {pet.Gender}, " +
                        $"pet breed name: {pet.BreedName}, pet category name: {pet.CategoryName}, pet description: {pet.Description}, " +
                        $"pet price: {pet.Price}, pet order id: {pet.OrderId}");
                }
            }

        }
    }
}