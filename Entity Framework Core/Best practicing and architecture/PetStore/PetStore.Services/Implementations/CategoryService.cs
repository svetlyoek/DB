namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Category;
    using PetStore.Services.Models.Food;
    using PetStore.Services.Models.Pet;
    using PetStore.Services.Models.Toy;
    using System;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly PetStoreDbContext data;

        public CategoryService(PetStoreDbContext data)
        {
            this.data = data;
        }


    }
}

