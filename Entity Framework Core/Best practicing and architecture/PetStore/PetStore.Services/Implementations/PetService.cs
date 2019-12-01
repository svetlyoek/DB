namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Pet;
    using System.Collections.Generic;
    using System.Linq;

    public class PetService : IPetService
    {
        private readonly PetStoreDbContext data;

        public PetService(PetStoreDbContext data)
        {
            this.data = data;
        }


        public void Add(PetCreateServiceModel model)
        {
            var pet = new Pet()
            {
                Name = model.Name,
                Birthdate = model.Birthdate,
                Gender = model.Gender,
                Price = model.Price,
                Description = model.Description,
                BreedId = model.BreedId,
                CategoryId = model.CategoryId,
                OrderId = model.OrderId
            };

            this.data.Pets.Add(pet);

            this.data.SaveChanges();
        }

        public void Remove(int id)
        {
            var pet = this.data.Pets
                .Where(p => p.Id == id)
                .FirstOrDefault();

            this.data.Pets.Remove(pet);

            this.data.SaveChanges();

        }

        public PetCreateServiceModel Edit(int id)
        {
            var pet = this.data.Pets
                .Where(p => p.Id == id)
                .FirstOrDefault();

            var petToProject = new PetCreateServiceModel
            {
                Name = pet.Name,
                Birthdate = pet.Birthdate,
                Gender = pet.Gender,
                Price = pet.Price,
                Description = pet.Description,
                BreedId = pet.BreedId,
                CategoryId = pet.CategoryId,
                OrderId = pet.OrderId
            };

            return petToProject;
        }

        public void Edit(PetEditListingModel model)
        {
            var pet = this.data.Pets
                .Where(p => p.Id == model.Id)
                .FirstOrDefault();

            pet.Id = model.Id;
            pet.Name = model.Name;
            pet.Birthdate = model.Birthdate;
            pet.Gender = model.Gender;
            pet.Description = model.Description;
            pet.Price = model.Price;
            pet.BreedId = model.BreedId;
            pet.CategoryId = model.CategoryId;
            pet.OrderId = model.OrderId;

            this.data.SaveChanges();
        }

        public IEnumerable<PetListingModel> All()
        {
            var pets = this.data.Pets
                .Select(p => new PetListingModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Breed = p.Breed.Name,
                    Category = p.Category.Name,
                    Order = p.Order.Name,
                    Price = p.Price

                })
                .ToList();

            return pets;
        }

        public PetFullListingModel Details(int id)
        {
            var pet = this.data.Pets
                .Where(p => p.Id == id)
                .Select(p => new PetFullListingModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Birthdate = p.Birthdate,
                    Gender = p.Gender,
                    Breed = p.Breed.Name,
                    BreedId = p.BreedId,
                    Category = p.Category.Name,
                    CategoryId = p.CategoryId,
                    Order = p.Order.Name,
                    OrderId = p.OrderId,
                    Price = p.Price,
                    Description = p.Description

                })
                .FirstOrDefault();

            return pet;
        }
    }
}
