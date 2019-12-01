namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Contracts;
    using PetStore.Services.Models.Brand;
    using PetStore.Services.Models.Food;
    using PetStore.Services.Models.Toy;
    using System;
    using System.Linq;

    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;

        public BrandService(PetStoreDbContext data)
        {
            this.data = data;
        }

     


    }
}
